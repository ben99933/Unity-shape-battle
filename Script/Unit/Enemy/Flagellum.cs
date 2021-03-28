using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagellum : MonoBehaviour
{
    public Type type;
    public GameObject target;
    // Start is called before the first frame update
    void Awake()
    {
        
        
    }
    void Start()
    {
        target = GameObject.Find("Player");
        gameObject.GetComponent<Unit>().health = gameObject.GetComponent<Unit>().level * 20 + 50;
        gameObject.GetComponent<Unit>().atk = gameObject.GetComponent<Unit>().level * 2 + 10;
        gameObject.GetComponent<Unit>().speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        MoveToPlayer();
        if (gameObject.GetComponent<Unit>().health <=0) {
            SetDead();
        }
    }
    public static int Exp(int lv) {
        return (int)(Mathf.Log10(Mathf.Log10(lv * lv)) * 10);
    }
    void FacePlayer() {
        Vector3 dir = target.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        gameObject.GetComponent<Unit>().body.transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }
    void MoveToPlayer() {
        Vector2 dir =(Vector2) (target.transform.position - gameObject.transform.position);
        Vector2 d = dir.normalized;
        gameObject.GetComponent<Unit>().rb.velocity = d * gameObject.GetComponent<Unit>().speed;
    }
    void SetDead()
    {
        GameObject levelHandler = GameObject.Find("LevelHandler");
        levelHandler.GetComponent<LevelHandler>().enemyList.Remove(gameObject);
        Destroy(gameObject);
    }
    //=========================
    public enum Type {normal};
}
