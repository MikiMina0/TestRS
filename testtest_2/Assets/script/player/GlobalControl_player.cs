using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl_player : MonoBehaviour {
    public static GlobalControl_player control;
    /*public static GameObject slot_p;
    public static GameObject inv;

    //public static readonly List<Item> items = new List<Item>();
    public static readonly List<GameObject> slots = new List<GameObject>();

    private inventory3 inv3; */
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != null)
        {
            Destroy(gameObject);
        }
        DontDestroyChildOnLoad(this.gameObject);

    }
    public static void DontDestroyChildOnLoad(GameObject child)
    {
        Transform parentTransform = child.transform;

        // If this object doesn't have a parent then its the root transform.
        while (parentTransform.parent != null)
        {
            // Keep going up the chain.
            parentTransform = parentTransform.parent;
        }
        GameObject.DontDestroyOnLoad(parentTransform.gameObject);
    }
}
