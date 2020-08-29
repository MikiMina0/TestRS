using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {
    public static GlobalControl control;
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
    }  
}
