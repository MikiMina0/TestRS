using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.ES_MessageSystem;


public class PlayerUIimage_test : MonoBehaviour
{

    public Animator player_UI;
    private ES_MessageSystem con;
    void Start()
    {
        con = FindObjectOfType<ES_MessageSystem>();
        player_UI = this.GetComponent<Animator>();
        player_UI.SetBool("Tbool", false); // idle

    }

    // Update is called once per frame
    void Update()
    {
        if(con.IsCompleted == true)
        {
            player_UI.SetBool("Tbool",false); // idle
        }       

        if (player_UI.GetBool("Tbool") == false)
        {
            Debug.Log("idle");
        }
        if (player_UI.GetBool("Tbool") == true)
        {
            Debug.Log("talk");
        }
        if(player_UI.GetBool("Tbool") == true)
        {
            nextstate2();
        }
    }

    public void nextstate2() //講完回到待命狀態
    {
        AnimatorStateInfo info = player_UI.GetCurrentAnimatorStateInfo(0);

        // player_UI.SetBool("Tbool", true); // talk

       // if (info.IsName("meicen_talk"))
       //     {
                if (info.normalizedTime >= 1.0f)
                {
                    player_UI.SetBool("Tbool", false); // idle
                    return;
                }
       //     }


    }
    public void test()
    {
        player_UI.SetBool("Tbool", true);  // talk
    }
}

