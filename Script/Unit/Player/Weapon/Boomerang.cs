using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public int bullet;
    public int atk;
    public int powerLevel;
    public bool isEncharging;
    public float enchargeRate;
    public GameObject bulletObject;
    public enum Mode { straight, left, right };
    public Mode mode;
    // Start is called before the first frame update
    void Awake()
    {
        powerLevel = 1;
        enchargeRate = 1;
        bullet = ItemWeapon.GetMaxBullet(ItemWeapon.Type.boomerang);
        atk = (int)(Player.GetAtk(Player.level) * ItemWeapon.GetDamageRate(ItemWeapon.Type.boomerang));
        bulletObject = Bullets.bulletBoomerang;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && bullet >= 1 && !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse2))
        {
            enchargeRate += 3 * Time.deltaTime;
            mode = Mode.left;
        }else if (Input.GetKeyUp(KeyCode.Mouse0) && bullet >= 1)
        {
            Attack();
            enchargeRate = 1;
            bullet -= 1;
            mode = Mode.left;
        }else if(Input.GetKey(KeyCode.Mouse1) && bullet >= 1 && !Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse2))
        {
            enchargeRate += 3 * Time.deltaTime;
            mode = Mode.right;
        }else if (Input.GetKeyUp(KeyCode.Mouse1) && bullet >= 1)
        {
            Attack();
            enchargeRate = 1;
            bullet -= 1;
            mode = Mode.right;
        }
        else if (Input.GetKey(KeyCode.Mouse2) && bullet >= 1 && !Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1))
        {
            enchargeRate += 3 * Time.deltaTime;
            mode = Mode.straight;
            
        }
        else if (Input.GetKeyUp(KeyCode.Mouse2) && bullet >= 1 && powerLevel >1)
        {
            Attack();
            enchargeRate = 1;
            bullet -= 1;
            mode = Mode.straight;
            powerLevel = 0;
        }
    }
    void Attack() {
        bulletObject = Instantiate(bulletObject, gameObject.transform.position, gameObject.GetComponent<Unit>().body.transform.rotation);
        bulletObject.GetComponent<Bullet_Boomerang>().enchargeRate = enchargeRate;
        bulletObject.GetComponent<Bullet_Boomerang>().parent = gameObject;
        bulletObject.GetComponent<Bullet_Boomerang>().moveMode = mode;
        bulletObject.GetComponent<Bullet_Boomerang>().atk = (int)(atk * enchargeRate) * powerLevel;
        bulletObject.transform.parent = GameObject.Find("Bullet").transform;
        bulletObject = Bullets.bulletBoomerang;
    }
    public void BoomerangReturn() {
        if (powerLevel < 5)
        {
            powerLevel += 1;
        }
        else {
        }
        
        bullet += 1;
    }
}
