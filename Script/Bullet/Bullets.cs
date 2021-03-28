using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public static GameObject BulletMG;
    public static GameObject BulletLaser;
    public static GameObject bulletBoomerang;
     public static void Init()
     {
        BulletMG = Resources.Load<GameObject>("Prefab/Bullet/MGbullet");
        BulletLaser = Resources.Load<GameObject>("Prefab/Bullet/LaserBullet");
        bulletBoomerang = Resources.Load<GameObject>("Prefab/Bullet/BoomerangBullet");
        Debug.Log("bullet init completed");
     }
}
