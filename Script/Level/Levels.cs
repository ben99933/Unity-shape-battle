using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels
{

    public static Level level1_1, level1_2, level1_3, level1_4, level1_5;





    public static void Init() {
        level1_1 = new Level() {
            id = 1, monsterLevel = 1,
            icon = Resources.Load<Sprite>("Textures/UI/Menu/Level/1_1")
        };
    }
    public static Level GetLevel(int id) {
        switch (id) {
            case 1:
                return level1_1;
            case 2:
                return level1_2;
            case 3:
                return level1_3;
            case 4:
                return level1_4;
            case 5:
                return level1_5;
            default:
                return null;

        }
    }
    public static string GetLevelSceneName(int id) {
        switch (id)
        {
            case 1:
                return "Level1_1";
            case 2:
                return "Level1_2";
            case 3:
                return "Level1_3";
            case 4:
                return "Level1_4";
            case 5:
                return "Level1_5";
            default:
                return null;

        }
    }
        
}
