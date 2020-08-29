using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour {
    public int slot_id;
    public Item item_what;
    public int amount;
    public int i_id;
    public Sprite i_sprite;
    Image this_sprite;
    Text amount_text;
    GameObject this_g;
    inventory3_noglobal inv_no;

    private void Start()
    {
        inv_no= GameObject.Find("bagsystem").GetComponent<inventory3_noglobal>();
        this_g = this.gameObject;
       // amount = 1;
        this_sprite = this.GetComponent<Image>();
        amount_text = this.transform.GetChild(0).GetComponent<Text>();
    }
    private void Update()
    {
        item_what = inv_no.curitems[slot_id];
        i_id = item_what.ID;
        i_sprite = item_what.Sprite;
        this_sprite.sprite = item_what.Sprite;
        amount_text.text = amount.ToString();
        this_g.name = item_what.Title;
    }
}
