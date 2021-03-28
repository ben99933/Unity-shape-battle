using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boomerang : MonoBehaviour
{
    public int atk;
    public float speed;
    public GameObject parent;
    public GameObject body;
    public float enchargeRate;
    public float rotateSpeed;
    public bool canBack;
    public Boomerang.Mode moveMode;
    bool isGoback;
    // Start is called before the first frame update
    void Awake()
    {
        canBack = false;
        isGoback = false;
    }
    void Start()
    {

        speed = enchargeRate * 2;
        if (moveMode == Boomerang.Mode.straight) {
            rotateSpeed = 0;
            StartCoroutine(StraightGoBack());
        } else if (moveMode == Boomerang.Mode.left) {
            rotateSpeed = speed * speed * 5;
        } else if (moveMode == Boomerang.Mode.right) {
            rotateSpeed = speed * speed * -5;
        }
        StartCoroutine(SetCanBack());
    }

    // Update is called once per frame
    void Update()
    {
        if (moveMode == Boomerang.Mode.straight) {
            if (!isGoback)
            {
                gameObject.transform.Translate((new Vector3(0, speed, 0)) * Time.deltaTime);
                body.transform.Rotate(new Vector3(0, 0, 999 * Time.deltaTime));
            }
            else {
                Vector3 v = parent.transform.position - gameObject.transform.position;
                v = v.normalized * speed;
                gameObject.transform.position += v * Time.deltaTime;
                body.transform.Rotate(new Vector3(0, 0, 999 * Time.deltaTime));
            }
            
        } else {
            if (!isGoback)
            {
                gameObject.transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
                gameObject.transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
                body.transform.Rotate(new Vector3(0, 0, 999 * Time.deltaTime));
            }
            else
            {
                Vector3 v = parent.transform.position - gameObject.transform.position;
                gameObject.transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
                gameObject.transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
                gameObject.transform.position += speed * v.normalized * Time.deltaTime;
                body.transform.Rotate(new Vector3(0, 0, 999 * Time.deltaTime));
            }
            
        }
        

    }
    private void OnTriggerEnter2D(Collider2D c)
    {

        if (c.tag == "Armor")
        {
            if (c.GetComponent<Armor>().parent.tag != parent.tag)
            {
                c.GetComponent<Armor>().GetDamage(atk);
                Vector3 dir = c.gameObject.transform.position - gameObject.transform.position;
                Vector2 v = dir;
            }
            if (c.GetComponent<Armor>().parent.tag == parent.tag) {
                if (canBack) {
                    c.GetComponent<Armor>().parent.GetComponent<Boomerang>().BoomerangReturn();
                    Debug.Log("Back");
                    SetDead();
                }
            }
        }
    }
    void SetDead() {
        Destroy(gameObject);
    }
    IEnumerator SetCanBack() {
        yield return new WaitForSeconds(0.5F);
        canBack = true;
    }
    IEnumerator StraightGoBack() {
        yield return new WaitForSeconds(1F);
        isGoback = true;
    }
}
