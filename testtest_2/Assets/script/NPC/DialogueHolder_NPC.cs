using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;
using RemptyTool.ES_MessageSystem;


public class DialogueHolder_NPC : MonoBehaviour
{
   // private ES_MessageSystem mys;
    public string who; //設定框框進入的是什麼人！
    private Animationcontorler player;
    public NPCcontroller_test talk;
    public ES_MessageSystem msgSys;
    public DialogueHolder_player player_check;
    public option option_0;
    public TextAsset txt;
    TextAsset txt2;
    public bool[] story_check;

    public Sprite cha;
    Sprite M,Flower, Fu2;
    public RuntimeAnimatorController anim;
    RuntimeAnimatorController M_anim,Flower_anim, Fu2_anim;
    TextAsset txt_mom,txt_flower, txt_TV,txt_book, txt_fish, txt_Fu2;
    //test pass_text;
    ///
    public string[] log;
    public string[] log_final,log_checked;
    public string test;
    string log2_string;
    //int story_count=3;
    public List<int> story_number_assign=new List<int>();
    //public int story_n;
    public bool big_image;
    public bool talk_check;
    public bool story_checked_volumeup;
    public float time,time_1;
    public string logrender;

    void Start()
    {
        // story_number_assign=new int[story_count];
        player = FindObjectOfType<Animationcontorler>();
        player_check = GameObject.Find("player").gameObject.transform.GetChild(0).gameObject.GetComponent<DialogueHolder_player>();
        talk = NPCcontroller_test.ins.gameObject.GetComponent<NPCcontroller_test>();
        msgSys = GameObject.Find("talkmanager").GetComponent<ES_MessageSystem>();

        option_0 = GameObject.Find("talkmanager").GetComponent<option>();


        // pass_text=this.GetComponent<test>();
        //
        M = Resources.Load<Sprite>("NPC/mom_idle_257x396_00");
        Flower = Resources.Load<Sprite>("NPC/flower_idle_257x396_anim_00");
       // Fu2 = Resources.Load<Sprite>("NPC/FU_character_0");
        //
        M_anim= Resources.Load<RuntimeAnimatorController>("animator/mon_combine_257x396");
        Flower_anim = Resources.Load<RuntimeAnimatorController>("animator/flower_anim_257x396");
        Fu2_anim = Resources.Load<RuntimeAnimatorController>("animator/FU2_anim");
        //
        txt_mom=Resources.Load<TextAsset>("txt/ui2");
        txt_flower=Resources.Load<TextAsset>("txt/ui_flower");
        txt_Fu2 = Resources.Load<TextAsset>("txt/ui_Fu2");
        txt_TV= Resources.Load<TextAsset>("txt/ui_TV");
        txt_book = Resources.Load<TextAsset>("txt/ui_book");
        txt_fish = Resources.Load<TextAsset>("txt/ui_fish");
        //一開始先用程式打好資料放在格子裡面
        if (who=="NPC_mom"){
            anim=M_anim;
            cha=M;
            txt=txt_mom;
        }else if(who=="NPC_flower")
        {
            anim=Flower_anim;
            cha=Flower;
            txt=txt_flower;
        }else if (who == "NPC_fu2")
        {
             anim = Fu2_anim;
            cha = Fu2;
            txt = txt_Fu2; 
        }
        else if(who== "TV")
        {
            //anim=Flower_anim;
           // cha=Flower;
            txt= txt_TV;
        }
        else if (who == "book")
        {
            txt = txt_book;
        }
        else if (who == "fish")
        {
            txt = txt_fish;
        }

        story_check = new bool[5];
        check_big_image();
        pass_test(txt);//用box，遇到誰，誰的資料就會轉換 輸出log

    }

    // Update is called once per frame
    void Update()
    {

       check_talk_test();
       check_story();
       // if () {
       // }
    }

    void pass_test(TextAsset t) //分割對話選項，或是loop
    {
        log = t.text.Split('"');
        for (int i = 0; i < 3; i++)
        {
            log[i] = log[i].Replace("\n", "");
        }
        
    }
    public void check_story(){
        //UsageCase_0.textList.Add(option_0.s[5]);
        for (int i=0;i<5;i++){
            if (story_number_assign.Count > 0) //故事止指派數字多於0
            {
                if (whereSpawn.story_n != story_number_assign[i]) //指派的故事數字沒有跟目前的數字對應到
                {
                    log2_string = log[whereSpawn.story_n];
                    log_final = log2_string.Split('/');
                    if (log_final.Length < 2)
                    {
                        logrender = log[whereSpawn.story_n];
                        break;
                    }
                    else if (log_final.Length == 2)
                    {

                        if (whereSpawn.story[whereSpawn.story_n] == false) //沒有完成
                        {
                            logrender = log_final[0];
                            break;
                        }
                        else if (whereSpawn.story[whereSpawn.story_n] == true) //有完成，並且故事會+1
                        {

                            logrender = log_final[1];
                           // whereSpawn.story_n++;
                            break;
                        }
                    }
                }
                else if (whereSpawn.story_n == story_number_assign[i]) //有對應到
                {

                    log_checked = log[whereSpawn.story_n].Split('^');
                    if (whereSpawn.story[whereSpawn.story_n] == false)
                    {
                        //talk.txt = log[whereSpawn.story_n];
                        logrender = log_checked[0];
                        break;
                    }
                    else if (whereSpawn.story[whereSpawn.story_n] == true)
                    {
                        //test = option_0.s[5];
                        logrender = log_checked[1];
                       // talk.txt = test;
                        break;
                    }
                }
            } else if (story_number_assign.Count==0) {
               // Debug.Log("!");
                log2_string = log[whereSpawn.story_n];
                log_final = log2_string.Split('/');
                logrender = log_final[0];
                break;

            }
            else {
                logrender = log[whereSpawn.story_n];
                break;
            }

        }
        
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "talkcollider")
        {
            talk_check =true;
            talk.iswho = who;
            if(player_check.NPC_big_YN==false){
            talk.NPC_image.sprite = cha;
            talk.NPC_anim.runtimeAnimatorController = anim;
            }
            else
            {
            talk.NPC_B_image.sprite = cha;
            talk.NPC_B_anim.runtimeAnimatorController = anim;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "talkcollider")
        {
            talk_check=false;
            talk.iswho = null;
            talk.txt = null;
          /*  talk.NPC_image.sprite = null;
            talk.NPC_anim.runtimeAnimatorController = null;
            talk.txt = null; */
        }
    }
    void check_big_image() {
        if (this.gameObject.name == "NPC_fu2")
        {
            big_image = true;
        }
        else {
            big_image = false;
        }

    }

    void check_talk_test(){
        //  time= time+0.01f;

        if (talk_check == true) {
            if (talk.time - talk.time_i > 1.5f || talk.time_i == 0) {
                if (msgSys.talkstart == false)
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        talk.txt=logrender;
                        talk.read(); //talk = true
                        player.canmove = false;

                    }
                }
            }
        }

    }

}
