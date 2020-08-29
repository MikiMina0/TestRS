using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationcontorler : MonoBehaviour
{
    public static Animationcontorler play_ins;

    public float moveSpeed;
    public float jumpForce;

    //private DialogueHolder_2 NPCtalk;
    //private thingtalk thingtalk;
    public Rigidbody2D control;
    private Animator anim;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public bool canmove = true; //判定人物可以移動
    void Awake()
    {
        if (play_ins == null)
            play_ins = this;
    }
    void Start()
    {
        control = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // NPCtalk =FindObjectOfType<DialogueHolder_2>();
        //thingtalk = FindObjectOfType<thingtalk>();
        canmove = true;
    }

    void Update()
    {

        if (!canmove)
        {
            control.velocity = Vector2.zero;
            anim.SetFloat("speed", 0);
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (Input.GetKey("left") || Input.GetKey("right"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                control.velocity = new Vector2(moveSpeed, control.velocity.y);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                control.velocity = new Vector2(-moveSpeed, control.velocity.y);
            }
        }
        else
        {
            control.velocity = new Vector2(0, control.velocity.y);

        }
        if (Input.GetKeyDown(KeyCode.X) && isGrounded)
        {
            control.velocity = new Vector2(control.velocity.x, jumpForce);
        }
        if(control.velocity.x<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(control.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        anim.SetFloat("speed", Mathf.Abs(control.velocity.x));
        anim.SetBool("Grounded", isGrounded);

    }


}
