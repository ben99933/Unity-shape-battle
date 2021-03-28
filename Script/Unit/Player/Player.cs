using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public static Type type;
    public static int level;
    public const int maxLevel = 30;
    public static int exp;
    public static int maxExp;
    public static float speed;
    public static ItemWeapon weapon;



    public static Sprite texture_square, texture_tringle, texture_arrow, texture_circle;
    public Player() {
    }
    public static void Init() {
        level = 1;
        type = Type.tringle;
        exp = 0;
        speed = 1;
        maxExp = GetMaxExp(level);
        texture_square = Resources.Load<Sprite>("Textures/Unit/Player/square");
        texture_tringle = Resources.Load<Sprite>("Textures/Unit/Player/tringle");
        texture_arrow = Resources.Load<Sprite>("Textures/Unit/Player/arrow");
        texture_circle = Resources.Load<Sprite>("Textures/Unit/Player/circle");
        weapon = Items.boomerang;
        Debug.Log("Player init completed");
    }

    //===============forge=========
    public enum Type {square, tringle,arrow,circle}
    /* 0 正方形
     * 1 三角形
     * 2 箭頭
     * 3 圓形
     */

    public static int GetMaxHealth(int lv, Type ty) {
        float f = 1;
        switch (ty) {
            case Type.tringle:
                f = 0.8F;
                break;
            case Type.square:
                f = 1;
                break;
            case Type.arrow:
                f = 0.75F;
                break;
            case Type.circle:
                f = 1.5F;
                break;
            default:
                f = 1F;
                break;
        }
        return (int)(f * (100 + (0.5 * lv * lv * f))); 
    }
    public static int GetMaxExp(int lv) {
        if (lv == 1)
        {
            return 200;
        }
        return (int)(100 + (1200 * System.Math.Log10(lv)));
    }
    public static float GetMaxVitality(int lv, Type ty) {
        float f = 1;
        switch (ty) {
            case Type.tringle:
                f = 1.35F;
                break;
            case Type.square:
                f = 1;
                break;
            case Type.arrow:
                f = 1.5F;
                break;
            case Type.circle:
                f = 0.75F;
                break;
            default:
                f = 1F;
                break;
        }
        return (int)(f * (100 + (5 * lv)));

    }
    public static float GetSpeed(Type ty) {
        float f = 3;
        switch (ty) {
            case Type.square:
                f = 3 * 1;
                break;
            case Type.tringle:
                f = 3 * 1.5F;
                break;
            case Type.circle:
                f = 3 * 0.75F;
                break;
            case Type.arrow:
                f = 3 * 2F;
                break;
            default:
                f = 3;
                break;
        }
        return f;
    }
    public static int GetAtk(int lv) {
        return lv;
    }
    public static void Upgrade() {
        if (level < maxLevel) {
            level++;
            Debug.Log("player upgrade, now level:" + level);
        }
    }
    public static void GainExp(int e) {
        int _e = e;
        if (level < maxLevel) {
            while (_e >= (maxExp - exp)) {
                Upgrade();
                _e -= (maxExp - exp);
            }
        }
        
    }
    public static Item GetWeapon(Type ty) {
        return null;
    }

}
