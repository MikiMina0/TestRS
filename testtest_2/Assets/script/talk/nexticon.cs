using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RemptyTool.ES_MessageSystem;

public class nexticon : MonoBehaviour {
    private ES_MessageSystem con;
    private GameObject canvas, panel;
    public GameObject next;
    // Use this for initialization

    void Start () {
        canvas = GameObject.Find("Canvas");
        panel = canvas.transform.Find("Panel").gameObject;
        next = panel.transform.GetChild(6).gameObject;
        con = FindObjectOfType<ES_MessageSystem>();
        if (next == null)
        {
            Debug.Log("爛");
        }
        else
        {
            next.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        if (next != null)
        {
            if (con.IsCompleted == true)
            {
                next.SetActive(true);
            }
            else
            {
                next.SetActive(false);
            }
        }
        else
        {
            Debug.Log("爛");
        }
    }
}
