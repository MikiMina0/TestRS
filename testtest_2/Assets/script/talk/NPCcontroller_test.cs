using UnityEngine;
using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Sprites;
using RemptyTool.ES_MessageSystem;


public class NPCcontroller_test : MonoBehaviour {

    public static NPCcontroller_test ins;
    //public bool isTalk = false;  //有無對話開關
    private UsageCase UC;
   // public TextAsset txt;
    public string txt;
    public GameObject panel, Player_2D, NPC_2D, nametext, NPC_2D_big,NPC_change,selectscene_panel;
    private GameObject canvas;
    public Text text_word;
    private ES_MessageSystem msgSys;
    private Animationcontorler player;
    private DialogueHolder_player NPC;
    DialogueHolder_NPC DialogueHolder_NPC;
    public string iswho = null;  //偵測角色是誰
    public float time,time_i;

    public bool fade_P;

    //  string m_Path; //連結到專案檔的字串

    public Image NPC_image,NPC_B_image; //主要使用 
    public Animator NPC_anim,NPC_B_anim; //主要使用

    // Use this for initialization
    void Awake()
    {
        if (ins == null)
            ins = this;
    }

    void Start() {

        canvas = GameObject.Find("Canvas");
        selectscene_panel = canvas.transform.Find("selectscene_panel").gameObject;
        panel = canvas.transform.Find("Panel").gameObject;
        NPC_2D = panel.transform.GetChild(1).gameObject;
        NPC_2D_big = panel.transform.GetChild(2).gameObject;
        Player_2D = panel.transform.GetChild(3).gameObject;
        nametext = panel.transform.GetChild(6).gameObject;
        text_word = panel.transform.GetChild(4).gameObject.GetComponent<Text>();
        DialogueHolder_NPC = FindObjectOfType<DialogueHolder_NPC>();
        //NPC_change=NPC_2D;
        //--------------------
        NPC_image = NPC_2D.GetComponent<Image>();
        NPC_B_image = NPC_2D_big.GetComponent<Image>();
        NPC_anim = NPC_2D.GetComponent<Animator>();
        NPC_B_anim = NPC_2D_big.GetComponent<Animator>();
        //---------------------
        UC = this.GetComponent<UsageCase>();
        msgSys = this.GetComponent<ES_MessageSystem>();
        player = FindObjectOfType<Animationcontorler>();
        NPC = FindObjectOfType<DialogueHolder_player>();

        if (panel != null )
        {
            panel.SetActive(false);
            selectscene_panel.SetActive(false);
        }
        else
        {
            Debug.Log("Fuck!");
        }
        time_i = 0;
        //  Player_2D.SetActive(false);
        //  NPC_2D.SetActive(false);
        fade_P = true;
        NPC_2D_big.SetActive(false);

    }
    //
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyUp(KeyCode.Q))
        {
            whereSpawn.story_n=whereSpawn.story_n+1;
        }


        time = Time.time;

        if (msgSys.IsCompleted == false)  //如果開始對話，對話框會出現
         {
            player.canmove = false;
            fade_P = false;
            panel.SetActive(true); //
          //  if (iswho == "NPC_mom" || iswho == "NPC_flower")
           if(NPC.NPC_YN==true)
             {
                 Player_2D.SetActive(true);
                 nametext.SetActive(true);
                  if (NPC.NPC_big_YN == true)
                  {
                      NPC_2D_big.SetActive(true);
                      NPC_2D.SetActive(false);
                  }
                  if (NPC.NPC_big_YN == false)
                  {
                      NPC_2D_big.SetActive(false);
                      NPC_2D.SetActive(true);
                  }
            }
            else
             {
                 Player_2D.SetActive(false);
                 NPC_2D.SetActive(false);
                 NPC_2D_big.SetActive(false);
                 nametext.SetActive(false);
                 NPC_2D_big.SetActive(false);

            }
        }
         
  
        if (msgSys.IsCompleted == true)  //完成對話
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                fade_P = true;
                player.canmove = true;
                msgSys.msgText = "";
                msgSys.talkstart = false;
               // DialogueHolder_NPC.log_optionrecord=null;
            }
  
        }

    }

    public void read ()
    {
     //   if (time - time_i > 1.7f || time_i == 0)  //可以開始講話的時候
     //   {
            UC.ReadTextDataFromAsset(txt);
            time_i = time;  //抓取的時間
     //   }

    }
}
