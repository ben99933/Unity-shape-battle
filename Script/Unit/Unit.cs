using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public enum Type { player, Flagellum };
    public Type type;
    public int level;
    public int health;
    public int atk;
    public float speed;
    public GameObject body;
    public Rigidbody2D rb;
    // Start is called before the first frame update

    void Awake()
    {
        gameObject.GetComponent<Unit>().rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GetDamage(int d) {
        health -= d;
    }

    //==================================
    public static GameObject GetUnitGameObject(Type type) {
        switch (type) {
            case Type.Flagellum:
                return Units.flagellum_normal;
            default:
                return null;
        }
    }
}
