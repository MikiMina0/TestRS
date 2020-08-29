using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

    string[] t;
   // public Text dtext;
    //private string s = "";
    private DialogueManager dMAn;
   // public float delay = 0.1f;

    // Use this for initialization
    void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
        t = System.IO.File.ReadAllLines("Assets/ui2.txt");
       // StartCoroutine(ShowText());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
            if(Input.GetKeyUp(KeyCode.F))
            {
                dMAn.ShowBox(t[0]);
            }
        }
    }
  /*  IEnumerator ShowText()
    {
        for (int i = 0; i < t.Length; i++)
        {
            s = dMAn.ShowBox(t[0]).Substring(0, i);
            dtext.text = s;
            yield return new WaitForSeconds(delay);

        }
    }
    */
}
