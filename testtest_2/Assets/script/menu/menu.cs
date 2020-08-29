using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

    Animationcontorler player;

    public GameObject menu_gameobject,character,inventory,saveload,gameoption;
    public int index;
    public bool pauseEnabled = false;
    // Use this for initialization
    void Start () {
        menu_gameobject= GameObject.Find("menu");
        player = GameObject.Find("player").GetComponent<Animationcontorler>();
        character = menu_gameobject.transform.GetChild(2).gameObject;
        inventory = menu_gameobject.transform.GetChild(3).gameObject;
        saveload = menu_gameobject.transform.GetChild(4).gameObject;
        gameoption = menu_gameobject.transform.GetChild(5).gameObject;



        menu_gameobject.SetActive(false);
        index = 0;
        pauseEnabled = false;

    }

    // Update is called once per frame
    void Update () {
        open_close();
        menu_select();
    }

    void open_close() {
        if (Input.GetKeyDown("escape"))
        {
            if (pauseEnabled == true ) //如果是打開狀態就關掉
            {//關掉的動作	
                player.canmove = true;
                menu_gameobject.SetActive(false);
                pauseEnabled = false;
            }
            else if (pauseEnabled == false)  //如果是關掉狀態就打開
            {   //打開的動作	
                player.canmove = false;
                menu_gameobject.SetActive(true);
                pauseEnabled = true;
            }
        }
    }
    void menu_select() {
        switch (index) {
            case 0:
                character.SetActive(true);
                inventory.SetActive(false);
                saveload.SetActive(false);
                gameoption.SetActive(false);
                break;
            case 1:
                character.SetActive(false);
                inventory.SetActive(true);
                saveload.SetActive(false);
                gameoption.SetActive(false);
                break;
            case 2:
                character.SetActive(false);
                inventory.SetActive(false);
                saveload.SetActive(true);
                gameoption.SetActive(false);
                break;
            case 3:
                character.SetActive(false);
                inventory.SetActive(false);
                saveload.SetActive(false);
                gameoption.SetActive(true);
                break;
        }
    }
}
