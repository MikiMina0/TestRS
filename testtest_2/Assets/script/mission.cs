using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission : MonoBehaviour {

    DialogueHolder_NPC NPC;

    void Start () {
        NPC = FindObjectOfType<DialogueHolder_NPC>();

    }

    // Update is called once per frame
    void Update () {


    }
    void mission_talk_check() {
        if (whereSpawn.story[whereSpawn.story_n] == true)
        {
            if (NPC.story_check[whereSpawn.story_n] == true)
            {
                whereSpawn.story_n++;
            }
        }

    }

}
