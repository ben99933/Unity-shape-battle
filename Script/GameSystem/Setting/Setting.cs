using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public static bool isMute;
    public static int sound;
    public static bool isFullScreen;
    public static GameDifficulty difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Init() {
        sound = 100;
        isMute = false;
        isFullScreen = false;
        difficulty = GameDifficulty.normal;
        Debug.Log("Setting init comlpeted");
    }
    //====forge====
    public enum GameDifficulty { normal, hard };
}
