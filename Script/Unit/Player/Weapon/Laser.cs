using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int bullet;
    public int atk;
    public float cd_atk;
    public GameObject bulletObject;
    public GameObject target;
    // Start is called before the first frame update
    void Awake()
    {
        cd_atk = 0;
        bullet = ItemWeapon.GetMaxBullet(ItemWeapon.Type.laser);
        atk = (int)(Player.GetAtk(Player.level) * ItemWeapon.GetDamageRate(ItemWeapon.Type.laser));
        bulletObject = Bullets.BulletLaser;
    }
    void Start()
    {
        StartCoroutine(EnergyRecovery());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cd_atk <= 0 && bullet >= 10) {
            bullet -= 10;
            StartCoroutine(Attack());
            cd_atk = Items.laser.attackCD;
        }
        if (cd_atk > 0)
        {
            cd_atk -= 1 * Time.deltaTime;
        }
        else if (cd_atk < 0)
        {
            cd_atk = 0;
        }
    }
    IEnumerator Attack()
    {
        float faceAngle = gameObject.GetComponent<PlayerObject>().faceAngle;
        faceAngle = faceAngle / Mathf.Rad2Deg;
        Vector3 dir = new Vector3(Mathf.Sin(faceAngle), Mathf.Cos(faceAngle), 0);
        GameObject shotpoint = gameObject.GetComponent<PlayerObject>().shotPoint;
        RaycastHit2D hit = Physics2D.Raycast(shotpoint.transform.position, dir, 1000, LayerMask.GetMask("background"));
        Ray ray = new Ray(gameObject.transform.position, dir);
        bulletObject = Instantiate(bulletObject, gameObject.transform.position, gameObject.GetComponent<Unit>().body.transform.rotation);
        if (hit.collider != null && hit.collider.name != "EventBox")
        {
            target = hit.collider.gameObject;
            float dis = Vector3.Distance(shotpoint.transform.position, target.transform.position);
            bulletObject.transform.localScale = new Vector3(1, dis, 1);
        }
        else {
           
            bulletObject.transform.localScale = new Vector3(1, 100, 1);
        }
        bulletObject.GetComponent<BulletLaser>().atk = atk;
        bulletObject.GetComponent<BulletLaser>().parent = gameObject;
        bulletObject.transform.parent = GameObject.Find("Bullet").transform;
        yield return null;
        yield return new WaitForSeconds(0.3F);
        GameObject.Destroy(bulletObject);
        bulletObject = Bullets.BulletLaser;

    }
    IEnumerator EnergyRecovery() {
        for (int i = 0; i == 0; i+=0) {
            int max = ItemWeapon.GetMaxBullet(ItemWeapon.Type.laser);
            if (bullet < max)
            {
                bullet += 1;
            }
            else if (bullet > max)
            {
                bullet = max;
            }
            yield return new WaitForSeconds(0.3F);
        }
    }
}
