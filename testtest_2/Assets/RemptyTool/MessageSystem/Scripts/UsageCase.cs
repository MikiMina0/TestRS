using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RemptyTool.ES_MessageSystem;
using System.Text.RegularExpressions;
[RequireComponent(typeof(ES_MessageSystem))]
public class UsageCase : MonoBehaviour
{
    
    private ES_MessageSystem msgSys;  //
    public UnityEngine.UI.Text uiText;  // 選取Text
    private GameObject Canvas, Panel, Text;
    // public  TextAsset textAsset;   //txt文字劇本檔
    public List<string> textList = new List<string>();
    public int textIndex = 0;
    void Awake()
    {
        Canvas = GameObject.Find("Canvas");
        Panel = Canvas.transform.Find("Panel").gameObject;
        Text = Panel.transform.GetChild(4).gameObject;
        uiText = Text.GetComponent<UnityEngine.UI.Text>();


        msgSys = this.GetComponent<ES_MessageSystem>(); // 讀取ES的程式碼
      //  panel = GameObject.Find("Panel");
       // NPC = this.GetComponent<NPCcontroller_test>(); 
    /*    if (uiText == null) //如果沒有文字就會跑出Debug
        {
            Debug.LogError("UIText Component not assign.");
        }
        else   //有文字就會跑出來
         ReadTextDataFromAsset(textAsset); */  
        

        //add special chars and functions in other component.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);  //呼叫其程式碼的動作specialCharFuncMap
    }

    private void CustomizedFunction() //設定[UsageCase] 則會跑出Debug
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    public void ReadTextDataFromAsset(string _textAsset)  // 設定共通函式 讀取TXT檔 會處理的事情
    {
        textList.Clear();
        textList = new List<string>();
        textIndex = 0;
       // string test = _textAsset.Replace("\n", "");
        var lineTextData = _textAsset.Split('*');  //Split分割字串
        for(int i=0;i< lineTextData.Length; i++)
        {
            textList.Add(lineTextData[i]);
        }
    }

    void Update()
    {
        //You can sending the messages from strings or text-based files.
        // if (msgSys.IsCompleted)  // 如果IsCompleted跑完
        //    {
        //  NPC.isTalk = false;
        //  }
            //If the message is complete, stop updating text.
            if (msgSys.IsCompleted == false) //文字沒有跑完
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    //Continue the messages, stoping by [w] or [lr] keywords.
                    msgSys.Next();
                  //  msgSys.textSpeed -= 0.099f;
                }
              /*  if (Input.GetKeyUp(KeyCode.Z))
                {
                    msgSys.textSpeed = 0.1f;

                } */
                uiText.text = msgSys.text;
            }

        //Auto update from textList.
        //Debug.Log(msgSys.IsCompleted);
        //Debug.Log("3 - " + textIndex + " "+textList.Count);

            if (msgSys.IsCompleted == true && textIndex < textList.Count)  //確認文字跑完跟textindex 0 比文字數少時。
            {
                msgSys.SetText(textList[textIndex]);
                textIndex++;
        }
        

    }
}
