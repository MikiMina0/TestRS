using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private Animator a1;
    private Transform T1;
    private Animationcontorler player;
    public bool a1_B, a2_B, a3_B;// a4_B;
    public bool a2_finish, a3_finish; //a4_finish;
    public float test_time;
    public float testmove_time;
    public float attack_time;
    public float move;
    public float move_speed;
    float X;
    public bool move_bool;

    // Use this for initialization
    void Start()
    {
        a1 = GetComponent<Animator>();
        T1 = GetComponent<Transform>();
        player = FindObjectOfType<Animationcontorler>();
        attack_time = 0;
        a1_B = true;
        a2_B = false;
        a3_B = false;
        // a4_B = false;
        a2_finish = false;
        a3_finish = false;
        // a4_finish = false;
        move_bool = false;
        move_speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded == true)
        {
            attack_test();
        
        move_02();
        }
        if (move_bool == true)
        {
            a1.SetBool("move_bool",true);
            move_01();
            if (move_speed > 0)
            {
                move_speed -= 0.01f;
            }
            else
            {
                a1.SetBool("move_bool", false);
                move_bool = false;
            }
        }

    }
    void move_02()
    {
        
        if (move <= 0)
        {
          //  player.canmove = false;
            move_bool = false;
            X = T1.position.x;
            T1.position = new Vector2(X, T1.position.y);
            if (Input.GetKeyDown(KeyCode.V))
            {
                player.canmove = false;
                move_bool = true;
                move = testmove_time;
               // move_speed = 0.13f;
                move_speed = 0.15f;
            }
        }
        else
        {
            move -= Time.deltaTime;
        }
    }
    void move_01()
    {
        if(T1.localScale.x>0 )
        {
            X = T1.position.x;
            X += move_speed;
            T1.position = new Vector2(X, T1.position.y);
        }
        else if(T1.localScale.x < 0 )
        {
            X = T1.position.x;
            X -= move_speed;
            T1.position = new Vector2(X, T1.position.y);
        }
       /* if (Input.GetKey(KeyCode.RightArrow))
        {
            X = T1.position.x;
            X += move_speed;
            T1.position = new Vector2(X, T1.position.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            X = T1.position.x;
            X -= move_speed;
            T1.position = new Vector2(X, T1.position.y);
        }
        */
    }

    void attack_test()
    {
       /* if(attack_time == 0)
        {
            player.canmove = true;
        } */
        if (attack_time <= 0)
        {
            if (a1_B == true || a2_B == true || a3_B == true)
            {
                a1.SetBool("a1_bool", false);
                a1.SetBool("a2_bool", false);
                a1.SetBool("a3_bool", false);
                // a1.SetBool("a4_bool", false);
            }
            a1_B = false;
            a2_B = false;
            a3_B = false;
            // a4_B = false;
            a2_finish = false;
            a3_finish = false;
            // a4_finish = false;
            if (move_bool == true)
            { player.canmove = false; }
            else {
                player.canmove = true;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (a1_B == false)
                {
                    a1_B = true;
                    a1.SetBool("a1_bool", true);
                }
                attack_time = test_time;
            }
        }
        else
        {
            player.canmove = false;
            attack_time -= Time.deltaTime * 0.9f;
        }
        if (a1_B == true)
        {
            if (attack_time < 0.21f && attack_time > 0.1f)
            {
                if (a2_finish == false)
                {
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (a2_B == false)
                        {
                            a2_B = true;
                            a1.SetBool("a2_bool", true);
                            a2_finish = true;
                        }

                        attack_time = test_time;
                    }
                }
                else if (a2_finish == true && a3_finish == false)
                {
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (a3_B == false)
                        {
                            a3_B = true;
                            a1.SetBool("a3_bool", true);
                            a3_finish = true;
                        }
                        attack_time = test_time;
                    }
                }
            }

        }
    }



}

