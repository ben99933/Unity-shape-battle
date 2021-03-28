using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{

    //menu
    //setting
    public Slider slider_sound;
    public Button button_mute;
    public Toggle toggle_fullScreen;
    public Text text_difficulty;

    //level
    public Image image_playerShape;
    public Image image_levelIcon;
    public Level levelChoose;
    public Text text_playerInfo;
    public Image image_weapon;
    // Start is called before the first frame update
    void Start()
    {
        slider_sound.value = Setting.sound;
        button_mute.image.sprite = Setting.isMute ? Resources.Load<Sprite>("Textures/UI/Menu/mute") : Resources.Load<Sprite>("Textures/UI/Menu/voluble");
        toggle_fullScreen.isOn = Setting.isFullScreen;
        if (Setting.difficulty == Setting.GameDifficulty.normal) {
            text_difficulty.text = "normal";
        } else if (Setting.difficulty == Setting.GameDifficulty.hard) {
            text_difficulty.text = "hard";
        }
        levelChoose = Levels.level1_1;
        SetLevelTexture();
        SetImagePlayerShape();
        SetPlayerInfo();
        SetWeaponIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //=========================menu==========================
    public void Quit()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
    //=========================setting=======================
    public void SoundChange() {
        Setting.sound = (int)slider_sound.value;
    }
    public void ChangeMuteButton() {
        if (Setting.isMute)
        {
            Setting.isMute = false;
            button_mute.image.sprite = Resources.Load<Sprite>("Textures/UI/Menu/voluble");
        }
        else if(Setting.isMute == false)
        {
            Setting.isMute = true;
            button_mute.image.sprite = Resources.Load<Sprite>("Textures/UI/Menu/mute");
        }
        
    }
    public void ChangeFullScreen() {
        if (toggle_fullScreen.isOn == false) {
            Setting.isFullScreen = false;
            Screen.fullScreen = false;
            Debug.Log("Exit full screen");
        }else if (toggle_fullScreen.isOn == true) {
            Setting.isFullScreen = true;
            Screen.fullScreen = true;
            Debug.Log("Full screen");
        }
    }
    public void ChangeDifficulty() {
        if (Setting.difficulty == Setting.GameDifficulty.normal) {
            Setting.difficulty = Setting.GameDifficulty.hard;
            text_difficulty.text = "hard";
            Debug.Log("change difficulty : hard");
        } else if (Setting.difficulty == Setting.GameDifficulty.hard) {
            Setting.difficulty = Setting.GameDifficulty.normal;
            text_difficulty.text = "normal";
            Debug.Log("change difficulty : normal");
        }
    }


    //=========================level==========================
    void SetImagePlayerShape()
    {
        switch (Player.type)
        {
            case Player.Type.square:
                image_playerShape.sprite = Player.texture_square;
                break;
            case Player.Type.tringle:
                image_playerShape.sprite = Player.texture_tringle;
                break;
            case Player.Type.arrow:
                image_playerShape.sprite = Player.texture_arrow;
                break;
            case Player.Type.circle:
                image_playerShape.sprite = Player.texture_circle;
                break;
        }
    }
    void SetLevelTexture() {
        image_levelIcon.sprite = Levels.level1_1.icon;
    }
    public void ChangeChooseLevel(int levelId) {
        levelChoose = Levels.GetLevel(levelId);
        image_levelIcon.sprite = levelChoose.icon;
        Debug.Log("level change:" + levelChoose.id);
    }
    public void GameStart() {
        string name = Levels.GetLevelSceneName(levelChoose.id);
        Debug.Log("Load Scene: " + name);
        SceneManager.LoadScene(name);
    }
    public void ChangePlayerType() {
        string s = "";
        Player.Type ty = Player.type;
        if (ty == Player.Type.square) {
            Player.type = Player.Type.tringle;
            s = "tringle";
        } else if (ty == Player.Type.tringle) {
            Player.type = Player.Type.arrow;
            s = "arrow";
        } else if (ty == Player.Type.arrow) {
            Player.type = Player.Type.circle;
            s = "circle";
        } else if (Player.type == Player.Type.circle) {
            Player.type = Player.Type.square;
            s = "square";
        }
        SetImagePlayerShape();
        SetPlayerInfo();
        Debug.Log("player shape changed: " + s);
    }
    void SetPlayerInfo() {
        int health = Player.GetMaxHealth(Player.level, Player.type);
        int atk = Player.GetAtk(Player.level);
        float vitality = Player.GetMaxVitality(Player.level, Player.type);
        float speed = Player.GetSpeed(Player.type);
        text_playerInfo.text = "health: " + health + "\n" + "vitality: " + vitality + "\n" + "speed: " + speed + "\n" + "attack: " + atk;
    }
    void SetWeaponIcon() {
        image_weapon.sprite = Player.weapon.Icon;
    }
    public void ChangePlayerWeaponUp() {
        Item weapon = Player.weapon;
        if (weapon == Items.machine_gun) {
            Player.weapon = Items.laser;
        } else if (weapon == Items.laser) {
            Player.weapon = Items.boomerang;
        } else if (weapon == Items.boomerang) {
            Player.weapon = Items.machine_gun;
        }
        SetWeaponIcon();
    }
    public void ChangePlayerWeaponDown()//順序 迴力鏢 雷射 機槍
    {
        Item weapon = Player.weapon;
        if (weapon == Items.boomerang)
        {
            Player.weapon = Items.laser;
        }
        else if (weapon == Items.laser)
        {
            Player.weapon = Items.machine_gun;
        }
        else if (weapon == Items.machine_gun)
        {
            Player.weapon = Items.boomerang;
        }
        SetWeaponIcon();
    }
}
