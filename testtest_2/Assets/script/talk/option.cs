using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class option : MonoBehaviour {
    public int index = 0;
    public float yoffset;
    public GameObject option_0, Image, S_0, S_1;
    private GameObject canvas;
    NPCcontroller_test NPC_Talk;
    //DialogueHolder_NPC NPC_Talk;
    public Text test_s0, test_s1;
    float test_color_volume;
    string t;
    public string[] s;
    public float fadeInSpeed = 5f;

    // Use this for initialization
    void Awake() {
        NPC_Talk = GameObject.Find("talkmanager").GetComponent<NPCcontroller_test>();
       // NPC_Talk = FindObjectOfType<DialogueHolder_NPC>();
        canvas = GameObject.Find("Canvas");
        option_0 = canvas.transform.Find("option").gameObject;
        Image = option_0.transform.GetChild(0).gameObject;
        S_0 = option_0.transform.GetChild(1).gameObject;
        S_1 = option_0.transform.GetChild(2).gameObject;
        test_s0 = S_0.GetComponent<Text>();
        test_s1 = S_1.GetComponent<Text>();
        if (option_0 != null)
        {
            option_0.SetActive(false);
        }
        else
        {
            Debug.Log("Fuck!");
        }
        test_color_volume = 0;

    }
     void Start(){
     //   test_s0.color = new Color(test_s0.color.r, test_s0.color.g, test_s0.color.b, 0);
     //   test_s1.color = new Color(test_s1.color.r, test_s1.color.g, test_s1.color.b, 0);
        
      //  test_s0.color = new Color();
    }
    

    // Update is called once per frame
    void Update () {

        if (option_0.activeInHierarchy == true )
        {
            fadein();
        }else
        {
            test_color_volume = 0;
            test_s0.color = new Color(test_s0.color.r, test_s0.color.g, test_s0.color.b, 0);
            test_s1.color = new Color(test_s1.color.r, test_s1.color.g, test_s1.color.b, 0);
        }
        if (NPC_Talk.txt != null)
        {
          //  Debug.Log(NPC_Talk.txt);
            t = NPC_Talk.txt;
            s = t.Split('|');
            if (S_0.activeInHierarchy == true && S_1.activeInHierarchy == true)
            {
                S_0.GetComponent<Text>().text = s[1];
                S_1.GetComponent<Text>().text = s[3];
            }
         //   Debug.Log("ttttt");
        }
        if (option_0.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (index < 1)
                {
                    index++;
                    Vector2 position= S_1.GetComponent<RectTransform>().anchoredPosition;
                    Image.GetComponent<RectTransform>().anchoredPosition = position;
                }
            }
        if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (index > 0)
                {
                    index--;
                    Vector2 position = S_0.GetComponent<RectTransform>().anchoredPosition;
                    Image.GetComponent<RectTransform>().anchoredPosition = position;
                }
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.Z))
            {
            if (option_0.activeInHierarchy == true)
            {
                if (index == 0)
                {
                   // whereSpawn.story_n++;
                   whereSpawn.story[whereSpawn.story_n] =true;
                    /*s[1] = "";
                    s[3] = "";
                    s[4] = ""; */
                }
                else if (index == 1)
                {
                    whereSpawn.story[whereSpawn.story_n] = false;

                }
            }

            }
        }
   /* public void fade()
    {
        if (test_color_volume > -1f || test_s0.color.a > -1f || test_s1.color.a > -1f)
        {
            test_color_volume -= Time.deltaTime * fadeInSpeed;
            test_s0.color = new Color(test_s0.color.r, test_s0.color.g, test_s0.color.b, test_color_volume);
            test_s1.color = new Color(test_s1.color.r, test_s1.color.g, test_s1.color.b, test_color_volume);
        }
    } */
    public void fadein()
    {
       
        if (test_color_volume <1.1f || test_s0.color.a < 1.1f || test_s1.color.a < 1.1f)
        {
            test_color_volume += Time.deltaTime * fadeInSpeed;
            test_s0.color = new Color(test_s0.color.r, test_s0.color.g, test_s0.color.b, test_color_volume);
            test_s1.color = new Color(test_s1.color.r, test_s1.color.g, test_s1.color.b, test_color_volume);
        }
       
    }
    }
