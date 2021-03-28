using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isMove;
    public bool canMove;
    public bool isDash;
    public bool canDash;
    float speed;
    Vector2 movement;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        movement = new Vector2(0, 0);
        canMove = true;
        canDash = true;
        isMove = false;
        isDash = false;
        speed = gameObject.GetComponent<Unit>().speed;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && isMove && canDash &&(gameObject.GetComponent<PlayerObject>().vitality >= 30))
        {
            StartCoroutine(Dash());
        }
        SetCanMove();
    }
    void FixedUpdate()
    {
        Move();

    }
    void Move()
    {
        if (canMove) {
            Vector2 v = movement * speed;
            if ((v.x == 0) && (v.y == 0))
            {
                isMove = false;
            }
            else {
                isMove = true;
            }
            float f = isDash ? 4 : 1;
            rb.velocity = v * f;
        }
    }
    IEnumerator Dash() {
        isDash = true;
        canDash = false;
        gameObject.GetComponent<PlayerObject>().vitality -= 30;
        yield return new WaitForSeconds(0.15F);
        isDash = false;
        yield return new WaitForSeconds(0.85F);
        canDash = true;
    }
    void SetCanMove() {
        if (Player.weapon == Items.machine_gun) {
            bool can = gameObject.GetComponent<MachineGun>().isSettingGun ? false : true;
            canMove = can;
        } else if (Player.weapon == Items.laser) {

        }
        else if (Player.weapon == Items.boomerang)
        {
        }
    }
}
