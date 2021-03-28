using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBox_spawn : MonoBehaviour
{
    public enum EventAction {Spawn};
    public enum Condition { none, clearEnemy}
    public EventAction eventAction;
    public Condition condition;
    public bool canAnyUnitTrig;
    public bool isRepeated;
    public int maxSize;
    public List<GameObject> listGameObject = new List<GameObject>();
    public List<int> listAmount = new List<int>();
    public List<Vector3> listPosition = new List<Vector3>();
    public float spawnTime;
    GameObject levelHandler;
    int lv;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        levelHandler = GameObject.Find("LevelHandler");
        lv = levelHandler.GetComponent<LevelHandler>().level.monsterLevel;
        listAmount.Capacity = maxSize;
        listGameObject.Capacity = maxSize;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D c)
    {
            if (c.tag == "Armor")
            {
                if (condition == Condition.none)
                {
                    if (c.GetComponent<Armor>().parent.tag == "Player" && canAnyUnitTrig == false && eventAction == EventAction.Spawn)
                    {
                        for (int i = 0; i < maxSize; i++)
                        {
                            GameObject g = listGameObject[i];
                            int amount = listAmount[i];
                            Vector3 p = listPosition[i];
                            levelHandler.GetComponent<LevelHandler>().Spawn(g, lv, p, amount, spawnTime);
                            if (isRepeated == false)
                            {
                                GameObject.Destroy(gameObject);
                            }

                        }
                    }
                    else if (canAnyUnitTrig == true && eventAction == EventAction.Spawn)
                    {



                        if (isRepeated == false)
                        {
                            GameObject.Destroy(gameObject);
                        }

                    }
                }
                if (condition == Condition.clearEnemy)
                {
                    if (c.GetComponent<Armor>().parent.tag == "Player" && canAnyUnitTrig == false && eventAction == EventAction.Spawn)
                    {
                        for (int i = 0; i < maxSize; i++)
                        {
                            GameObject g = listGameObject[i];
                            int amount = listAmount[i];
                            Vector3 p = listPosition[i];
                            levelHandler.GetComponent<LevelHandler>().Spawn(g, lv, p, amount, spawnTime);
                            if (isRepeated == false)
                            {
                                GameObject.Destroy(gameObject);
                            }

                        }
                    }
                    else if (canAnyUnitTrig == true && eventAction == EventAction.Spawn)
                    {




                        if (isRepeated == false)
                        {
                            GameObject.Destroy(gameObject);
                        }
                    }
                }
            }
            
        }

}

