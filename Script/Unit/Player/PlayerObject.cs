using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{

    public int atk;
    public float vitality;
    public bool isRun;
    public bool isRoll;
    public bool isAttacking;
    public GameObject shotPoint;
    public ItemWeapon weapon;
    public float faceAngle;
    private void Awake()
    {
        isAttacking = false;
        isRun = false;
        isRoll = false;
        gameObject.GetComponent<Unit>().level = Player.level;
        gameObject.GetComponent<Unit>().health = Player.GetMaxHealth(Player.level, Player.type);
        vitality = Player.GetMaxVitality(Player.level, Player.type);
        atk = Player.GetAtk(Player.level);
        gameObject.GetComponent<Unit>().atk = atk;
        gameObject.GetComponent<Unit>().speed = Player.GetSpeed(Player.type);
        SetTexture(Player.type);
        AddAttackScript();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        SetIsRun();
        FaceMouse();
        //體力回復5/秒
        if (vitality < Player.GetMaxVitality(Player.level, Player.type)) {
            vitality += 5 * Time.deltaTime;
        } else if (vitality > Player.GetMaxVitality(Player.level, Player.type)) {
            vitality = Player.GetMaxVitality(Player.level, Player.type);
        }
    }
    void FixedUpdate()
    {

    }
    //body
    void SetIsRun() {
        if (Input.GetKey(KeyCode.W) == false && (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false))
        {
            isRun = false;
        }
        else {
            isRun = true;
        }
    }
    void SetTexture(Player.Type type) {
        Sprite sprite = null;
        switch (type)
        {
            case Player.Type.tringle:
                sprite = Player.texture_tringle;
                break;
            case Player.Type.square:
                sprite = Player.texture_square;
                break;
            case Player.Type.arrow:
                sprite = Player.texture_arrow;
                break;
            case Player.Type.circle:
                sprite = Player.texture_circle;
                break;
            default:
                sprite = null;
                break;
        }
        gameObject.GetComponent<Unit>().body.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    void SetColor() {
        float r, g, b;
        r = Random.Range(0, 255);
        g = Random.Range(0, 255);
        b = Random.Range(0, 255);
        gameObject.GetComponent<Unit>().body.GetComponent<SpriteRenderer>().color = new Color(r / 255F, g / 255F, b / 255F);
    }
    void FaceMouse() {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        faceAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        gameObject.GetComponent<Unit>().body.transform.rotation = Quaternion.AngleAxis(faceAngle, Vector3.back);

    }
    //attack script
    void AddAttackScript (){
        if (Player.weapon == Items.boomerang)
        {
            gameObject.AddComponent<Boomerang>();
        }
        else if (Player.weapon == Items.laser)
        {
            gameObject.AddComponent<Laser>();
        }
        else if (Player.weapon == Items.machine_gun)
            gameObject.AddComponent<MachineGun>();
        {
        }
    }
}
