using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class select_script : MonoBehaviour {
    public GameObject canvas, maplist, select_panel, select,t;
    public GameObject[] map;
    public Animationcontorler Animationcontorler;
    public NPCcontroller_test NPCcontroller_test;
    private loading loading;
    public bool select_bool, select_bool2,selected_bool;
    public int index = 0;
    public int story_index,tt,story_v;
    public float k,k2; //可以避免重複按對話的時間
    public Animator scene_anim;
    public Image scene_image;

    // Use this for initialization
    void Start() {
        tt = 0;
        map = new GameObject[5];
        Animationcontorler = GameObject.Find("player").GetComponent<Animationcontorler>();
        loading = FindObjectOfType<loading>();
        NPCcontroller_test = NPCcontroller_test.ins.gameObject.GetComponent<NPCcontroller_test>();

        canvas = GameObject.Find("Canvas");
        select_panel = canvas.transform.Find("selectscene_panel").gameObject;
        select = select_panel.transform.GetChild(0).gameObject;
        maplist = select_panel.transform.GetChild(1).gameObject;

        scene_anim = select_panel.GetComponent<Animator>();
        scene_image= select_panel.GetComponent<Image>();
       /* for (int i = 1; i < 4; i++) {
            maplist.transform.GetChild(i).gameObject.SetActive(false);
        } */
        for (int i = 0; i < 5; i++)
        {
            t = maplist.transform.GetChild(i).gameObject;
          /*  if (t.activeInHierarchy == false)
            {  */
                map[tt] = maplist.transform.GetChild(i).gameObject;
                map[tt].SetActive(false);
                tt++;
            //}
        }
        map[0].GetComponent<Text>().text = "浮士德";
        //select_panel.SetActive(false);

        k = 0;
        k2=0; 
        story_index = 3;
    }

    void Update() {
        selectscene();
       // check_story();
        if (select_panel.activeInHierarchy == true)
        {
            selected();
        }
            if (k != 0 && k > 0) {
                k = k - 0.1f;}
        fade();
        
        //map[tt - 1].GetComponent<Text>().text = "取消";
       // map[tt - 1]
    }
   /* public void check2() {
        tt = 0;
        for (int i = 0; i < 5; i++)
        {
            t = maplist.transform.GetChild(i).gameObject;
            if (t.activeInHierarchy == true)
            {
                map[tt] = maplist.transform.GetChild(i).gameObject;
                tt++;
            }

        }
    } */
    public void check_story() {
        for (int i = 0; i < 4; i++)
        {
            if(whereSpawn.story_n == i){
                maplist.transform.GetChild(i).gameObject.SetActive(true);
                 maplist.transform.GetChild(i+1).gameObject.SetActive(true);
                map[i+1].GetComponent<Text>().text = "取消";
            }
        }
        if (whereSpawn.story_n == 1) {
            map[1].GetComponent<Text>().text = "浮士德2";
        }
        else if (whereSpawn.story_n == 2) {
            map[2].GetComponent<Text>().text = "浮士德3";
            story_index = 1;
        }
        else if (whereSpawn.story_n == 3)
        {
            map[3].GetComponent<Text>().text = "浮士德4";
            story_index = 0;
        }
    }
    private void selectscene()
    {

        if (select_panel.activeInHierarchy == true)
        {
            Animationcontorler.canmove = false;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (index < whereSpawn.story_n+1)
                {
                    index++;
                    Vector2 position = map[index].GetComponent<RectTransform>().anchoredPosition;
                    select.GetComponent<RectTransform>().anchoredPosition = position;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (index > 0)
                {
                    index--;
                    Vector2 position = map[index].GetComponent<RectTransform>().anchoredPosition;
                    select.GetComponent<RectTransform>().anchoredPosition = position;
                }
            }

        }

    }

    public void selected()
    {

        if (index == whereSpawn.story_n)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                whereSpawn.where = 1;
                selected_bool = true;
                scene_anim.SetTrigger("close");
                k = 8;
                select_bool = false;
                loading.loadingachangescene(4);
            }
        }
        if (index == whereSpawn.story_n+1)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                scene_anim.SetTrigger("close");
               // index = 0;
                k = 8;
                select_bool = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            scene_anim.SetTrigger("close");
            index = 0;
            select_bool = false;
        }

    }
    public void vector_reset() {
        Vector2 position = map[0].GetComponent<RectTransform>().anchoredPosition;
        select.GetComponent<RectTransform>().anchoredPosition = position;
    }
    public void fade() {
        if (scene_image.color.a < 0.1f && select_bool == false)
        {
            NPCcontroller_test.text_word.text = "";
            select_panel.SetActive(false);
            NPCcontroller_test.panel.SetActive(false);
            Animationcontorler.canmove = true;

        }
    }

}
