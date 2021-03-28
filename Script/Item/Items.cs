using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public static ItemWeapon machine_gun;
    public static ItemWeapon laser;
    public static ItemWeapon boomerang;

    public static void Init() {
        machine_gun = new ItemWeapon("machine_gun", 1001, ItemWeapon.Type.MG, 0.05F);
        machine_gun.Icon = Resources.Load<Sprite>("Textures/UI/Menu/Weapon/MG");
        laser = new ItemWeapon("laser", 1002, ItemWeapon.Type.laser, 1F);
        laser.Icon = Resources.Load<Sprite>("Textures/UI/Menu/Weapon/laser");
        boomerang = new ItemWeapon("boomerang", 1004, ItemWeapon.Type.boomerang, 0);
        boomerang.Icon = Resources.Load<Sprite>("Textures/UI/Menu/Weapon/boomerang");
        Debug.Log("Item init completed");
    }
}
