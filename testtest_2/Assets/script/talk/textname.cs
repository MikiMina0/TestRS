using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.ES_MessageSystem;


public class textname : MonoBehaviour {
    private GameObject canvas, panel,text;
    private Text T;
    private NPCcontroller_test NPC;
	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
        panel = canvas.transform.Find("Panel").gameObject;
        text = panel.transform.GetChild(5).gameObject;

        T = text.GetComponent<Text>();
        NPC = FindObjectOfType<NPCcontroller_test>();
       // T.text = "Test";
	}
	
	// Update is called once per frame
	void Update () {
        if (NPC.panel.activeInHierarchy == false)
        {
            T.text = "";
        }
		
	}
    public void nametext(string n)
    {
        if(n == "mei")
        {
            T.text = "杜美心";
        }
        else  if (n == "mom")
        {
            T.text = "媽媽";
        }
    }
}
