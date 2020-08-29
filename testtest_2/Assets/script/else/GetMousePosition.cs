using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMousePosition : MonoBehaviour
{
    Text[] mes;
    string[] text;
    // Use this for initialization
    void Start()
    {
        mes = GameObject.Find("Canvas").GetComponentsInChildren<Text>();
        text = System.IO.File.ReadAllLines("Assets/ui.txt");
        for (int i = 0; i < text.Length; i++) Debug.Log(text[i]);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mes[0].text = text[0];
        }
     //   else
       //     mes[0].text = text[1];
        //Debug.Log (Input.mousePosition.x + "/" + Input.mousePosition.y);
        //Debug.Log (Screen.width + "/" + Screen.height);
    }
}
