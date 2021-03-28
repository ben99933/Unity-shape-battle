using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units
{
    public static GameObject obstacle;
    public static GameObject flagellum_normal;



    public static void Init() {
        obstacle = Resources.Load<GameObject>("Prefab/Object/Obstacle");
        flagellum_normal = Resources.Load<GameObject>("Prefab/Unit/Enemy/Flagellum/Flagellum_normal");

        Debug.Log("unit init complete");
    }
}
