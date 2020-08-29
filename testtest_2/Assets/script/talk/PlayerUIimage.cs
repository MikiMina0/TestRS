using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.ES_MessageSystem;


public class PlayerUIimage : MonoBehaviour {
    private GameObject canvas, panel, NPC,NPC_big, Player;
    private Animator anim_NPC, anim_Player,anim_NPC_big;
    DialogueHolder_player play_check;

    void Awake () {
        canvas = GameObject.Find("Canvas");
        panel = canvas.transform.Find("Panel").gameObject;
        NPC = panel.transform.GetChild(1).gameObject;
        NPC_big = panel.transform.GetChild(2).gameObject;
        Player = panel.transform.GetChild(3).gameObject;
        
        anim_NPC = NPC.GetComponent<Animator>();
        anim_Player = Player.GetComponent<Animator>();
        anim_NPC_big = NPC.GetComponent<Animator>();
        play_check=FindObjectOfType<DialogueHolder_player>();
    }

    // Update is called once per frame
    void Update () {

        if (NPC.activeInHierarchy == false && Player.activeInHierarchy == false) //物件隱藏則動畫不啟動
        {
            anim_NPC.enabled = false;
            anim_Player.enabled = false;
            anim_NPC_big.enabled=false;
        }
        else 
        {
            anim_Player.enabled = true;
            anim_Player.enabled = true;
            anim_NPC_big.enabled = true;
        }
    }
    public void PlayTtoI()
    {
        AnimatorStateInfo P = anim_Player.GetCurrentAnimatorStateInfo(0);
        if (P.IsName("meicen_talk"))
        {
            if (P.normalizedTime >= 1.0f)
            {
                anim_Player.SetBool("Tbool", false); // idle
                return;
            }
        }
    }
    public void NPCTtoI()
    {
        AnimatorStateInfo N = anim_NPC.GetCurrentAnimatorStateInfo(0);
        if (N.IsName("mon_talk"))
        {
            if (N.normalizedTime >= 1.0f)
            {
                anim_NPC.SetBool("Tbool", false); // idle
                return;
            }
        }
        Debug.Log("!");
    }
    public void test(string name)
    {
        if (name == "mei")
        {
            // anim_Player.SetBool("Tbool", false);  // talk
            anim_Player.SetBool("Tbool", true);  // talk
            anim_Player.SetTrigger("Trigger");
            //   anim_Player.SetBool("Tbool", false);  // talk
            //   anim_NPC.SetBool("Tbool", false);  // talk

        }
        else if (name == "mei_happy")
        {
            anim_Player.SetBool("happy_bool", true);
        }
        else if (name == "mom")
        {
            anim_NPC.SetBool("Tbool", true);  // talk
            // anim_Player.SetBool("Tbool", false);  // talk
            anim_NPC.SetTrigger("Trigger");
        }
        else if (name == "mom_happy")
        {
            anim_NPC.SetBool("happy_bool", true);  // talk
        }

    }
    /*public void test()
    {
            anim_Player.SetBool("Tbool", true);  // talk
    }
    public void test2()
    {
            anim_NPC.SetBool("Tbool", true);  // talk
    }
    */
    public void allidle()
    {
        anim_NPC.SetBool("Tbool", true);  // talk
        anim_Player.SetBool("Tbool", true);  // talk
    }
}

