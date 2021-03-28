using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLoad : MonoBehaviour
{
    public Image load_line;
    public Text load_text;
    const float precent = 10;
    public static float p;
    public static bool isCompleted;
    // Start is called before the first frame update
    private void Awake()
    {
        p = 0;
        isCompleted = false;
        load_line.fillAmount = 0;
        load_text.text = "Loading";
    }

    void Start()
    {
        StartCoroutine(StartInit(1));
        

    }

    void Init(int number)
    {
        
        switch (number) {
            case 1:
                Items.Init();
                Setting.Init();
                Player.Init();
                break;
            case 2:
                Units.Init();
                Bullets.Init();
                break;
            case 3:
                Levels.Init();
                break;

        }
    }

    IEnumerator StartInit(int number) {   
        yield return new WaitForSeconds(0.3F);
        if (number <= 10) {
            Init(number);
            p += 1;
            load_line.fillAmount += 0.1F;
            if (number == 10)
            {
                isCompleted = true;
                Debug.Log("Init completed!");
                SceneManager.LoadScene("Menu");
            }
            else {
                StartCoroutine(StartInit(number + 1));
            }            
        }

    }
}
