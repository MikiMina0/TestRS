using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dtext;
    public bool dialogActive;

    // Use this for initialization
    void Start() {
        dBox.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (dialogActive && Input.GetKeyDown(KeyCode.F))
        {
            dBox.SetActive(false);
            dialogActive = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dtext.text = dialogue;
    }


}
    
