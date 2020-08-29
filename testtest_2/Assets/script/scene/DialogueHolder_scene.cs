using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder_scene : MonoBehaviour {
    public select_script select_script;
    public Animationcontorler Animationcontorler;
    public UsageCase UsageCase;
    public NPCcontroller_test talk;
    public bool in_check;
    private Animator scene_anim;
    string string_where;
    // public int tranform;
    // Use this for initialization
    void Start () {
       // select_script = FindObjectOfType<select_script>();
       //select_script = GameObject.Find("talkmanager").GetComponent<select_script>();
        select_script = this.GetComponent<select_script>();
        Animationcontorler = GameObject.Find("player").GetComponent<Animationcontorler>();
        UsageCase = GameObject.Find("talkmanager").GetComponent<UsageCase>();
        talk = NPCcontroller_test.ins.gameObject.GetComponent<NPCcontroller_test>();
        string_where = "該去哪裡呢?";
    }

    // Update is called once per frame
    void Update () {
		openscenepanel();
	}
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "player")
        {
            in_check=true; }
    }
 /*   private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            Debug.Log("000");
            if (select_script.select_bool == false)
            {
                if (Input.GetKeyUp(KeyCode.Z))
                {
                    select_script.select_panel.SetActive(true);
                    select_script.select_bool = true;
                    select_script.time = 0;
                    select_script.time_i = 0;
                }
            }
        }
    }  */
        private void OnTriggerExit2D(Collider2D other){
            if (other.gameObject.name == "player")
        {
            in_check=false;
        }
    }
    void openscenepanel(){
        if(in_check==true){
            if (select_script.select_bool == false && select_script.selected_bool == false)
            {
              //  Debug.Log("222");
                if (select_script.k < 0 || select_script.k == 0)
                {
                    if (Input.GetKeyUp(KeyCode.Z))
                    {
                        Debug.Log("開啟選擇框");
                        select_script.select_panel.SetActive(true);
                        talk.panel.SetActive(true);
                        UsageCase.ReadTextDataFromAsset(string_where);
                        select_script.select_bool = true;
                        select_script.index = 0;
                        select_script.check_story();
                        select_script.vector_reset();
                        Debug.Log("開啟選擇框2");
                    }
                }
            }
        }
    }
}
