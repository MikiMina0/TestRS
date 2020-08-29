using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueHolder_player : MonoBehaviour
{
    // private ES_MessageSystem mys;
    public bool NPC_YN ;
    public bool NPC_big_YN ;
    public int num;
    public GameObject where_num;
    public bool[] check_story;
    // Use this for initialization
    void Start()
    {
        check_story=new bool[4];
        where_num= GameObject.Find("number");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
        whereSpawn.story_n=whereSpawn.story_n+1;
        }
        for(int i=0;i<4;i++){
        check_story[i]=whereSpawn.story[i];
        }
        if (where_num!=null) {
            where_num.GetComponent<Text>().text = whereSpawn.story_n.ToString();
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "NPC")
        {
            NPC_YN = true;
        }
        if (other.gameObject.GetComponent<DialogueHolder_NPC>() != null)
        {
            if (other.gameObject.GetComponent<DialogueHolder_NPC>().big_image == true)
            {
                NPC_big_YN = true;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "NPC")
        {
            NPC_YN = true;
        }
        if (other.gameObject.GetComponent<DialogueHolder_NPC>() != null)
        {
            if (other.gameObject.GetComponent<DialogueHolder_NPC>().big_image == true)
            {
                NPC_big_YN = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        NPC_YN = false;
        NPC_big_YN = false;

    }

}
