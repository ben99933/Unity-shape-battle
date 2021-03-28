using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour
{
    public GameObject parent;
    public int atk;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = parent.GetComponent<Unit>().body.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Armor")
        {
            if (c.GetComponent<Armor>().parent.tag != parent.tag)
            {
                c.GetComponent<Armor>().GetDamage(atk);
            }
        }
    }
}
