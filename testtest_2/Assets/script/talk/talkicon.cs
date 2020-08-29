using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class talkicon : MonoBehaviour {

    private GameObject icon;

    void Start () {
        icon = gameObject.transform.GetChild(0).gameObject; //讀取子物件
        icon.SetActive(false); //顯示圖片
    }
	
	void Update () {
    }

        private void OnTriggerStay2D(Collider2D other)
    {

        if(other.gameObject.name == "talkcollider")
        {
            icon.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)  //進入某個空間就會顯示
    {
        if (other.gameObject.name == "talkcollider")
        {
            icon.SetActive(false);
        }
        
        }
    }
