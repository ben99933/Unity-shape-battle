using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{

    public int bullet;
    public bool isSettingGun;
    public bool isReloading;
    public int atk;
    public float cd_atk;
    public GameObject bulletObject;
    void Awake()
    {
        cd_atk = 0;
        isSettingGun = false;
        isReloading = false;
        bullet = ItemWeapon.GetMaxBullet(ItemWeapon.Type.MG);
        atk = (int)(Player.GetAtk(Player.level) * ItemWeapon.GetDamageRate(ItemWeapon.Type.MG));
        bulletObject = Bullets.BulletMG;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isSettingGun && bullet >= 1 && cd_atk <= 0) {
            bullet -= 1;
            StartCoroutine(Attack());
            cd_atk = Items.machine_gun.attackCD;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && isReloading == false) {
            isSettingGun = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isSettingGun = false;
        }
        if (isSettingGun) {
            gameObject.GetComponent<PlayerObject>().vitality -= 20 * Time.deltaTime;
            if (gameObject.GetComponent<PlayerObject>().vitality < 40) {
                isSettingGun = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && isSettingGun == false && isReloading == false) {
            StartCoroutine(Reload());
        }
        if (cd_atk > 0) {
            cd_atk -= 1 * Time.deltaTime;
        } else if (cd_atk < 0) {
            cd_atk = 0;
        }
    }
    IEnumerator Attack() {
        if (isSettingGun) {
            bulletObject = Instantiate(bulletObject, gameObject.transform.position, gameObject.GetComponent<Unit>().body.transform.rotation);
            
            bulletObject.GetComponent<Bullet_MG>().parent = gameObject;
            bulletObject.GetComponent<Bullet_MG>().atk = atk;
            bulletObject.transform.parent = GameObject.Find("Bullet").transform;
            yield return new WaitForSeconds(Items.machine_gun.attackCD);
            bulletObject = Bullets.BulletMG;
        }

    }
    IEnumerator Reload() {
        isReloading = true;
        yield return new WaitForSeconds(5F);
        bullet = ItemWeapon.GetMaxBullet(ItemWeapon.Type.MG);
        isReloading = false;
    }
}
