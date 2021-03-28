using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D c)
    {

        if (c.tag == "Armor") {
            if (c.GetComponent<Armor>().parent.tag != parent.tag) {
                c.GetComponent<Armor>().GetDamage(parent.GetComponent<Unit>().atk);
                Vector3 dir = c.gameObject.transform.position - gameObject.transform.position;
                Vector2 v = dir;
                StartCoroutine(Knockback(c.GetComponent<Armor>().parent, v.normalized));
            }
        }
    }
    IEnumerator Knockback(GameObject g, Vector2 v)
    {
        for (int i = 1; i <= 1;i++) {
            g.transform.Translate((v.normalized / 10 ));
            yield return new WaitForSeconds(0.008F);
        }
    }
}
