using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.ES_MessageSystem;

public class Fadeinout : MonoBehaviour {

    //物件
    private GameObject o, Text, N, N_big, nametext, canvas, panel, P;    //對話盤
    //圖片
    private Image P_C, N_C, P_P_C, N_B_C;   //對話盤 NPC 主角
    //
    private Text Text_T, Text_name;
    //
    public float fadeInSpeed = 4.0f;
    private ES_MessageSystem mys;
    private NPCcontroller_test NPC;
    //位置
    private RectTransform N_vector, P_vector, N_B_vector;
    //
    float P_C_a, N_a, N_B_a, P_a;
    //
    DialogueHolder_player player;
    // Use this for initialization
    void Start() {

        canvas = GameObject.Find("Canvas");
        panel = canvas.transform.Find("Panel").gameObject;
        nametext = panel.transform.GetChild(5).gameObject;
        o = panel.transform.GetChild(0).gameObject;
        N = panel.transform.GetChild(1).gameObject;
        N_big = panel.transform.GetChild(2).gameObject;
        P = panel.transform.GetChild(3).gameObject;
        Text = panel.transform.GetChild(4).gameObject;

        P_C = o.GetComponent<Image>();
        N_C = N.GetComponent<Image>();
        N_B_C = N_big.GetComponent<Image>();
        P_P_C = P.GetComponent<Image>();

        N_vector = N.GetComponent<RectTransform>();
        N_B_vector = N_big.GetComponent<RectTransform>();
        P_vector = P.GetComponent<RectTransform>();


        Text_T = Text.GetComponent<Text>();
        Text_name = nametext.GetComponent<Text>();

        //   mys = FindObjectOfType<ES_MessageSystem>();
        NPC = FindObjectOfType<NPCcontroller_test>();
        player = FindObjectOfType<DialogueHolder_player>();
        P_C_a = 0;
        //立繪移動
        N_a = -171;
        N_B_a = -137;
        P_a = 155;
        //
        P_C.color = new Color(P_C.color.r, P_C.color.g, P_C.color.b, P_C_a);
        N_C.color = new Color(N_C.color.r, N_C.color.g, N_C.color.b, P_C_a);
        N_B_C.color = new Color(N_B_C.color.r, N_B_C.color.g, N_B_C.color.b, 0);

        P_P_C.color = new Color(P_P_C.color.r, P_P_C.color.g, P_P_C.color.b, P_C_a);
        Text_T.color = new Color(Text_T.color.r, Text_T.color.g, Text_T.color.b, P_C_a);
        Text_name.color = new Color(Text_name.color.r, Text_name.color.g, Text_name.color.b, P_C_a);

        N_vector.anchoredPosition = new Vector2(N_a, N_vector.anchoredPosition.y); //-157  73
        N_B_vector.anchoredPosition = new Vector2(N_B_a, N_B_vector.anchoredPosition.y);
        P_vector.anchoredPosition = new Vector2(P_a, P_vector.anchoredPosition.y); //142  60
    }

    // Update is called once per frame
    void Update() {

        if (NPC.fade_P == true) //結束對話
        {
            fadeout();
            if (player.NPC_big_YN == true) {
                fadeoutNPC_B();
            }
            else
            {
                fadeoutNPC();
            }
        }
        if (NPC.fade_P == false) //開始對話
        {
            fadein();
            if (player.NPC_big_YN == true) {
                fadeinNPC_B();
            }
            else
            {
                fadeinNPC();
            }
        }

    }
    public void fadeout()
    {
        if (P_C.color.a > -1f || Text_T.color.a > -1f || P_P_C.color.a > -1f)
        {
            P_C_a -= Time.deltaTime * fadeInSpeed;
            P_C.color = new Color(P_C.color.r, P_C.color.g, P_C.color.b, P_C_a);
            Text_T.color = new Color(Text_T.color.r, Text_T.color.g, Text_T.color.b, P_C_a);
            P_P_C.color = new Color(P_P_C.color.r, P_P_C.color.g, P_P_C.color.b, P_C_a);
        }
        if (Text_T.color.a > -1f || Text_name.color.a > -1f )
        {
            P_C_a -= Time.deltaTime * fadeInSpeed;
            Text_T.color = new Color(Text_T.color.r, Text_T.color.g, Text_T.color.b, P_C_a);
            Text_name.color = new Color(Text_name.color.r, Text_name.color.g, Text_name.color.b, P_C_a);

        }
        if (P_C.color.a < 0.1f)
        {
            NPC.panel.SetActive(false);
        }
        if (P_vector.anchoredPosition.x < 156f)
            {
                P_a += Time.deltaTime * fadeInSpeed * 10;
                P_vector.anchoredPosition = new Vector2(P_a, P_vector.anchoredPosition.y);
            }
        }
    
    public void fadein() // 0→1
        {
            if (P_C.color.a < 1.1f || Text_T.color.a < 1.1f || P_P_C.color.a < 1.1f)
            {
                P_C_a += Time.deltaTime * fadeInSpeed;
                P_C.color = new Color(P_C.color.r, P_C.color.g, P_C.color.b, P_C_a);
                Text_T.color = new Color(Text_T.color.r, Text_T.color.g, Text_T.color.b, P_C_a);
                P_P_C.color = new Color(P_P_C.color.r, P_P_C.color.g, P_P_C.color.b, P_C_a);
            }
            if (Text_T.color.a < 1.1f || Text_name.color.a < 1.1f  )
            {
                P_C_a += Time.deltaTime * fadeInSpeed;
                Text_T.color = new Color(Text_T.color.r, Text_T.color.g, Text_T.color.b, P_C_a);
                Text_name.color = new Color(Text_name.color.r, Text_name.color.g, Text_name.color.b, P_C_a);
            }

        if (P_vector.anchoredPosition.x > 141f)
            {
                P_a -= Time.deltaTime * fadeInSpeed * 10;
                P_vector.anchoredPosition = new Vector2(P_a, P_vector.anchoredPosition.y);
            }
        }

    public void fadeinNPC() {
        if ( N_C.color.a < 1.1f)
        {
            P_C_a += Time.deltaTime * fadeInSpeed;
            N_C.color = new Color(N_C.color.r, N_C.color.g, N_C.color.b, P_C_a);
        }
        if (N_vector.anchoredPosition.x < -158f)
        {
            N_a += Time.deltaTime * fadeInSpeed * 10;
            N_vector.anchoredPosition = new Vector2(N_a, N_vector.anchoredPosition.y);
        }
    }
    public void fadeoutNPC()
    {
        if ( N_C.color.a > -1f)
        {
            P_C_a -= Time.deltaTime * fadeInSpeed;
            N_C.color = new Color(N_C.color.r, N_C.color.g, N_C.color.b, P_C_a);
        }
        if (N_vector.anchoredPosition.x > -171f)
        {
            N_a -= Time.deltaTime * fadeInSpeed * 10;
            N_vector.anchoredPosition = new Vector2(N_a, N_vector.anchoredPosition.y);
        }
    }
    public void fadeinNPC_B()
    {
        if (N_B_C.color.a < 1.1f)
        {
            P_C_a += Time.deltaTime * fadeInSpeed;
            N_B_C.color = new Color(N_B_C.color.r, N_B_C.color.g, N_B_C.color.b, P_C_a);
        }
        if (N_B_vector.anchoredPosition.x < -124f)
        {
            N_B_a += Time.deltaTime * fadeInSpeed * 10;
            N_B_vector.anchoredPosition = new Vector2(N_B_a, N_B_vector.anchoredPosition.y);
        }
    }
    public void fadeoutNPC_B()
    {
        if (N_B_C.color.a > -1f)
        {
            P_C_a -= Time.deltaTime * fadeInSpeed;
            N_B_C.color = new Color(N_B_C.color.r, N_B_C.color.g, N_B_C.color.b, P_C_a);
        }
        if (N_B_vector.anchoredPosition.x > -137f)
        {
            N_B_a -= Time.deltaTime * fadeInSpeed * 10;
            N_B_vector.anchoredPosition = new Vector2(N_B_a, N_B_vector.anchoredPosition.y);
        }
    }



    }
