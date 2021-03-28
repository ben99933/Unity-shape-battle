using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBox_Door : MonoBehaviour
{

    public GameObject door;
    public Door.Status action;
    GameObject levelHandler;
    public enum Condition {ClearEnemy, PlayerTouch}
    public Condition condition;
    public bool isRepeated;
    public bool canAnyUnitTrig;
    // Start is called before the first frame update
    void Start()
    {
        levelHandler = GameObject.Find("LevelHandler");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.tag == "Armor"  && condition == Condition.ClearEnemy)
        {
            int enemyAmount = levelHandler.GetComponent<LevelHandler>().enemyList.Count;
            if (enemyAmount == 0)
            {
                door.GetComponent<Door>().status = action;
                if (isRepeated == false)
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }
        if (c.tag == "Armor" && condition == Condition.PlayerTouch)
        {
            if (c.GetComponent<Armor>().parent.tag == "Player" && canAnyUnitTrig == false)
            {
                door.GetComponent<Door>().status = action;
                if (isRepeated == false)
                {
                    GameObject.Destroy(gameObject);
                }
            }
            else if (canAnyUnitTrig == true)
            {
                door.GetComponent<Door>().status = action;
                if (isRepeated == false)
                {
                    GameObject.Destroy(gameObject);
                }
            }
        }
    }
}
