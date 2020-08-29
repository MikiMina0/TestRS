using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl_bagsystem : MonoBehaviour {
    public static GlobalControl_bagsystem bagsystem;
    /*public static GameObject slot_p;
    public static GameObject inv;

    //public static readonly List<Item> items = new List<Item>();
    public static readonly List<GameObject> slots = new List<GameObject>();

    private inventory3 inv3; */
    void Awake()
    {
        if (bagsystem == null)
        {
            DontDestroyOnLoad(gameObject);
            bagsystem = this;
        }
        else if (bagsystem != null)
        {
            Destroy(gameObject);
        } 
    }  
}
