using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class story : MonoBehaviour {

    public DialogueHolder_NPC[] NPC;
    int[] story_assgin;

    void Start()
    {
       // NPC[] = DialogueHolder_NPC.ins.gameObject.GetComponent<DialogueHolder_NPC>();

        //story_assgin = new int[5];
        NPC = new DialogueHolder_NPC[5];
        NPC[0]= Resources.Load<DialogueHolder_NPC>("prefab/NPC_flower");
        NPC[1]= Resources.Load<DialogueHolder_NPC>("prefab/NPC_mom");
        
        for (int i = 0; i < 5; i++) {
            if (NPC[i] != null)
            {
            NPC[i].story_number_assign.Clear();
            }
        }  
        for (int i = 0; i < 5; i++) {

            // story_assgin[i] = i;
            //    NPC[i].story_number_assign = story_assgin;
            if (NPC[i] != null)
            {
                NPC[i].story_number_assign.Add(i);
            }
        }


    }
}
