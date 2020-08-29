using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RemptyTool.ES_MessageSystem
{
    /// <summary>The messageSystem is made by Rempty EmptyStudio. 
    /// UserFunction
    ///     SetText(string) -> Make the system to print or execute the commands.
    ///     Next()          -> If the system is WaitingForNext, then it will continue the remaining contents.
    ///     AddSpecialCharToFuncMap(string _str, Action _act)   -> You can add your customized special-characters into the function map.
    /// Parameters
    ///     IsCompleted     -> Is the input text parsing completely by the system.
    ///     text            -> The result, witch you can show on your interface as a dialog.
    ///     IsWaitingForNext-> Waiting for user input -> The Next() function.
    ///     textSpeed       -> Setting the updating period of text.
    /// </summary> 
    public class ES_MessageSystem : MonoBehaviour
    {


        public bool IsCompleted { get { return IsMsgCompleted; } } //設定布林，預設為IsMsgCompleted
        public string text { get { return msgText; } }  //設定字串，預設為msgText
        public bool IsWaitingForNext { get { return IsWaitingForNextToGo; } } //布林，預設為IsWaitingForNextToGo
        public float textSpeed = 0.05f; //Updating period of text. The actual period may not less than deltaTime.

        private const char SPECIAL_CHAR_STAR = '[';  //const可以用來創建陣列常量、指標常量、指向常量的指標等：
        private const char SPECIAL_CHAR_END = ']';
        private enum SpecialCharType { StartChar, CmdChar, EndChar, NormalChar } //設定擁有的變數
        public bool IsMsgCompleted = true;  //IsCompleted
        private bool IsOnSpecialChar = false;
        private bool IsWaitingForNextToGo = false;   //IsWaitingForNext
        private bool IsOnCmdEvent = false;
        private string specialCmd = "";
        public string msgText; //text
        private char lastChar = ' ';
        private Dictionary<string, Action> specialCharFuncMap = new Dictionary<string, Action>();
        private PlayerUIimage playCG;
        private textname Textname;
        public option option_0;
        UsageCase UsageCase_0;
        public bool talkstart;
        void Awake()
        {
            playCG = FindObjectOfType<PlayerUIimage>();
            Textname = FindObjectOfType<textname>();
            option_0 = FindObjectOfType<option>();
            UsageCase_0 = this.GetComponent<UsageCase>();

            //Register the Keywords Function.
            specialCharFuncMap.Add("w", () => StartCoroutine(CmdFun_w_Task()));
            specialCharFuncMap.Add("r", () => StartCoroutine(CmdFun_r_Task()));
            specialCharFuncMap.Add("l", () => StartCoroutine(CmdFun_l_Task()));
            specialCharFuncMap.Add("lr", () => StartCoroutine(CmdFun_lr_Task()));
            specialCharFuncMap.Add("option", () => StartCoroutine(CmdFun_option_Task()));
            specialCharFuncMap.Add("plus", () => StartCoroutine(CmdFun_plus_Task()));
            specialCharFuncMap.Add("mei", () => StartCoroutine(CmdFun_mei_Task()));
            specialCharFuncMap.Add("mom", () => StartCoroutine(CmdFun_mom_Task()));
            specialCharFuncMap.Add("mom_happy", () => StartCoroutine(CmdFun_mom_happy_Task()));
            specialCharFuncMap.Add("mei_happy", () => StartCoroutine(CmdFun_mei_happy_Task()));
            specialCharFuncMap.Add("P_name", () => StartCoroutine(CmdFun_P_name_Task()));
            specialCharFuncMap.Add("M_name", () => StartCoroutine(CmdFun_M_name_Task()));

        }


        #region Public Function
        public void AddSpecialCharToFuncMap(string _str, Action _act) //設立共通全域的fuction函式
        {
            specialCharFuncMap.Add(_str, _act);
        }
        #endregion
        //使用者的函數
        #region User Function 
        public void Next()
        {
            IsWaitingForNextToGo = false;
        }
        public void SetText(string _text)
        {
            StartCoroutine(SetTextTask(_text));
        }

        #endregion
        //關鍵字設定
        #region Keywords Function 
        private IEnumerator CmdFun_l_Task() // 停頓一下
        {
            IsOnCmdEvent = true;
            IsWaitingForNextToGo = true;
            yield return new WaitUntil(() => IsWaitingForNextToGo == false);
            IsOnCmdEvent = false;
            yield return null;
        }
        private IEnumerator CmdFun_r_Task() //出現到下面下一行
        {
            IsOnCmdEvent = true;
            msgText += '\n';
            IsOnCmdEvent = false;
            yield return null;
        }
        private IEnumerator CmdFun_w_Task()  // 停頓後，需要next()函數被啟動就會繼續執行，重製後的一行
        {
            IsOnCmdEvent = true;
            IsWaitingForNextToGo = true;
            yield return new WaitUntil(() => IsWaitingForNextToGo == false);
            msgText = "";   //Erase the messages.
            IsOnCmdEvent = false;
            yield return null;
        }
        private IEnumerator CmdFun_lr_Task() //停頓一下，需要next()函數被啟動就會繼續執行，直接出現下一行
        {
            IsOnCmdEvent = true;
            IsWaitingForNextToGo = true;
            yield return new WaitUntil(() => IsWaitingForNextToGo == false);
            msgText += '\n';
            IsOnCmdEvent = false;
            yield return null;
        }
        private IEnumerator CmdFun_option_Task() //停頓一下，需要next()函數被啟動就會繼續執行，直接出現下一行
        {
            // yield return new WaitUntil(() => IsWaitingForNextToGo == false);
            IsOnCmdEvent = true;
            //  playCG.allidle();
            yield return new WaitForSeconds(1f);
            IsWaitingForNextToGo = true;
            option_0.option_0.SetActive(true);
            yield return new WaitUntil(() => IsWaitingForNextToGo == false);
            option_0.Image.GetComponent<RectTransform>().anchoredPosition = option_0.S_0.GetComponent<RectTransform>().anchoredPosition;
            option_0.option_0.SetActive(false);
            msgText = "";
            UsageCase_0.textList.RemoveAt(1);
            yield return new WaitForSeconds(0.5f);
            if (option_0.index == 0){
                UsageCase_0.textList.Add(option_0.s[2]);
                Debug.Log("TT");
            }
            else if (option_0.index == 1){
                UsageCase_0.textList.Add(option_0.s[4]);
                Debug.Log("TT2");
            }
            option_0.index = 0;
            IsOnCmdEvent = false;
            yield return null;
        }
        private IEnumerator CmdFun_plus_Task() //停頓一下，需要next()函數被啟動就會繼續執行，直接出現下一行
        {
            whereSpawn.story_n++;
            yield return null;
        }
            private IEnumerator CmdFun_mei_Task()
        {
            playCG.test("mei");
            yield return null;
        }
        
         private IEnumerator CmdFun_mom_Task()
         {
            playCG.test("mom");
            yield return new WaitForSeconds(1f);

        }
        private IEnumerator CmdFun_mom_happy_Task()
        {
            playCG.test("mom_happy");
            yield return null;
        }
        private IEnumerator CmdFun_mei_happy_Task()
        {
            playCG.test("mei_happy");
            yield return null;
        }
        private IEnumerator CmdFun_P_name_Task()
         {
            Textname.nametext("mei");
            yield return null;
         }
        private IEnumerator CmdFun_M_name_Task()
         {
            Textname.nametext("mom");
            yield return null;
         }
         


        #endregion
        //訊息密碼
        #region Messages Core
        private void AddChar(char _char)
        {
            msgText += _char;
            lastChar = _char;
        }
        private SpecialCharType CheckSpecialChar(char _char)
        {
            if (_char == SPECIAL_CHAR_STAR)  //_char的文字是[
            {
                if (lastChar == SPECIAL_CHAR_STAR) //lastChar的文字是[
                {
                    specialCmd = "";
                    IsOnSpecialChar = false;
                    return SpecialCharType.NormalChar;
                }
                IsOnSpecialChar = true;  //lastChar的文字是其他
                return SpecialCharType.CmdChar;
            }
            else if (_char == SPECIAL_CHAR_END && IsOnSpecialChar) //_char的文字是] 以及 IsOnSpecialChar是true
            {
                //exe cmd!
                if (specialCharFuncMap.ContainsKey(specialCmd))  //關鍵字有包含specialCmd
                {
                    specialCharFuncMap[specialCmd]();
                    //Debug.Log("The keyword : [" + specialCmd + "] execute!");
                }
                else
                    Debug.LogError("The keyword : [" + specialCmd + "] is not exist!");
                specialCmd = "";
                IsOnSpecialChar = false;
                return SpecialCharType.EndChar;
            }
            else if (IsOnSpecialChar)
            {
                specialCmd += _char;
                return SpecialCharType.CmdChar;
            }
            return SpecialCharType.NormalChar;
        }
        private IEnumerator SetTextTask(string _text)
        {
            talkstart = true;
            IsOnSpecialChar = false;
            IsMsgCompleted = false;
            specialCmd = "";
            for (int i = 0; i < _text.Length; i++)
            {
                switch (CheckSpecialChar(_text[i]))
                {
                    case SpecialCharType.NormalChar:
                        AddChar(_text[i]);
                        lastChar = _text[i];
                        yield return new WaitForSeconds(textSpeed);
                        break;
                }
                lastChar = _text[i];
                yield return new WaitUntil(() => IsOnCmdEvent == false); // 直到IsOnCmdEvent==false時就會啟動
            }
            IsMsgCompleted = true;
            yield return null;
        }
        #endregion
    }
}

