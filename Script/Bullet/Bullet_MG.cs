using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_MG : MonoBehaviour
{
    public GameObject parent;
    public int atk;
    public float time;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = parent.GetComponent<Unit>().body.GetComponent<SpriteRenderer>().color;
        time = 0;
        float r = Random.Range(-5, 5);
        gameObject.transform.Rotate(new Vector3(0, 0, r));
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
        if (time >= 15) {
            SetDead();
        }
        gameObject.transform.Translate(new Vector3(0, 10, 0) * Time.deltaTime);
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
                StartCoroutine(Knockback(c.GetComponent<Armor>().parent, v.normalized));
                SetDead();
            }
        }
    }
    IEnumerator Knockback(GameObject g, Vector2 v)
    {
        for (int i = 1; i <= 1; i++)
        {
            g.transform.Translate((v.normalized / 10));
            yield return new WaitForSeconds(0.008F);
        }
    }
    void SetDead() {
        Destroy(gameObject);
    }
}
