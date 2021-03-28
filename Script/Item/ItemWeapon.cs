using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWeapon : Item
{
    public enum Type { MG, laser, boomerang };//機槍 雷射槍 霰彈槍 迴力鏢
    //機槍要設置腳架才能攻擊且不能移動 架槍會消耗體力
    //雷射槍可穿透敵人 攻擊倍率最大
    //迴力鏢可穿透  要等迴力鏢回來才可繼續攻擊 可續力 

    public Type type;
    public float attackCD;

    public ItemWeapon(string n, int ID, Type ty, float atkCD) : base(n, ID)
    {
        type = ty;
        name = n;
        id = ID;
        attackCD = atkCD;
    }
    public static int GetMaxBullet(Type ty) {
        switch (ty) {
            case Type.MG:
                return 1000;
            case Type.laser:
                return 100;
            case Type.boomerang:
                return 1;
            default:
                return 0;
        }
    }
    //攻擊倍率
    public static float GetDamageRate(Type ty) {
        switch (ty)
        {
            case Type.MG:
                return 15;
            case Type.laser:
                return 25;
            case Type.boomerang:
                return 2;
            default:
                return 0;
        }
    }
}
