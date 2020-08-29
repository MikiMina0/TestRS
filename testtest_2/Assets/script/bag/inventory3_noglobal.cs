using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class inventory3_noglobal : MonoBehaviour {

    public GameObject inventory,menu,canvas;
    public GameObject Panel_00;
    public GameObject Panel;
	public GameObject select;
    public GameObject selected;
	public GameObject info_panel;
	public GameObject title_text;
	public GameObject info_text;

    Itemdata database;
    Animationcontorler player;
    public fadeinout_public fade;
    public GameObject inventorySlot;
    public GameObject inventoryitem;

    public int slotAmount;
    public bool[] b_test;
    public int[] items_ID;
    
    public int S_index=0;
    public List<Item> curitems = new List<Item>(); //背包數量
    public List<GameObject> curslots = new List<GameObject>();
	public bool pauseEnabled = false;
	private RectTransform select_tranform;

    public bool select_b;
    Item selected_change;
    public int selected0_index;
    public int selected1_change_int;
    public int item_0_ID;

    Image panel_image,panel_info;
    float contorl_a=0;
    void Start () {
        b_test = new bool[24];
        items_ID = new int[24];
        fade= GetComponent<fadeinout_public>();
        database = GetComponent<Itemdata>();
        player=GameObject.Find("player").GetComponent<Animationcontorler>();
		slotAmount =24;

        canvas = GameObject.Find("Canvas"); 
        menu= canvas.transform.GetChild(5).gameObject;
        inventory = menu.transform.GetChild(3).gameObject;
        info_panel = inventory.transform.GetChild (0).gameObject;
        Panel_00 = inventory.transform.GetChild (1).gameObject;
        Panel = Panel_00.transform.GetChild(0).gameObject;
        select = Panel.transform.GetChild (0).gameObject;
        selected = Panel.transform.GetChild (1).gameObject;
        info_text = info_panel.transform.GetChild (1).gameObject;
		title_text= info_panel.transform.GetChild (0).gameObject;

        panel_image = Panel_00.GetComponent<Image>();
        panel_info = info_panel.GetComponent<Image>();

        select_tranform = select.GetComponent<RectTransform>();
       /* pauseEnabled = false;
		inventory.SetActive(false);
        Panel.SetActive(false);
        info_text.SetActive(false);
        title_text.SetActive(false);*/
        for (int i = 0; i < slotAmount; i++)
        {
            curitems.Add(new Item());
            curslots.Add(Instantiate(inventorySlot));
            curslots[i].GetComponent<slot>().slot_id = i;
            curslots[i].transform.SetParent(Panel.transform);
        }
       selected.SetActive(false);
    }
	void Update(){

	 /*	if (Input.GetKeyDown ("escape")) {
			if (pauseEnabled == true && fade.check_end== true) {//關掉的動作	
                player.canmove = true;
                Panel.SetActive(false);
                info_text.SetActive(false);
                title_text.SetActive(false);
                pauseEnabled = false;
            }
            else if (pauseEnabled == false && fade.check_end == false) {   //打開的動作	
                player.canmove = false;
                pauseEnabled = true;
                inventory.SetActive(true);
            }   
		}   */

        if (pauseEnabled == true)//打開的狀態
        {
            fade.fade_i(panel_image);
            fade.fade_i(panel_info);
            if (panel_image.color.a > 0.9f)
            {
                Panel.SetActive(true);
                info_text.SetActive(true);
                title_text.SetActive(true);
            }
                select_test();
        }
        else {

            fade.fade_o(panel_image);
            fade.fade_o(panel_info);
            if (panel_image.color.a < 0.1f)
            {
                inventory.SetActive(false); //關掉
            }
        } 
		
	if(Input.GetKeyDown(KeyCode.A)){
		AddItem(0);
	}
	if(Input.GetKeyDown(KeyCode.S)){
		AddItem(1);
	}
    if (Input.GetKeyDown(KeyCode.F))
    {
        AddItem(2);
    }
        for (int i = 0; i < curitems.Count; i++)
        {
 
            if (curslots[i].transform.childCount == 0)
            {
                curitems[i]= database.FetchItemByID(-1);
                b_test[i] = false;

            }
            if (curslots[i].transform.childCount > 0)
            {
                    b_test[i] = true; 
             }

                items_ID[i]=curitems[i].ID;
        }

        if(selected_change!=null){
        selected1_change_int=selected_change.ID;
        }

        if (curslots[0].transform.childCount > 0)
        {
            item_0_ID = curslots[0].transform.GetChild(0).GetComponent<item>().item_what.ID;
        }
        }
    /*
	void canmove(){
		Animationcontorler player = GameObject.Find ("player").GetComponent<Animationcontorler>();
		if (pauseEnabled == true) {
			player.canmove = false;
		} else 
		{
			player.canmove = true;
		}
	} */
    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        if (CheckIfItemIsInInventory(itemToAdd))
        {
            for (int i = 0; i < curitems.Count; i++)  // 計算擷取該物件裡面的數量數字
            {
                if (curitems[i].ID == id)
                {
                    item data = curslots[i].transform.GetChild(0).GetComponent<item>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < curitems.Count; i++)
            {
                if (curitems[i].ID == -1)
                {
                    curitems[i] = itemToAdd; //輸入物品的id
                    GameObject itemobj = Instantiate(inventoryitem);  //複製新的gameobject
                    itemobj.GetComponent<item>().item_what = itemToAdd;  //gameobject 物件為什麼
                    itemobj.GetComponent<item>().slot_id = i;
                    itemobj.transform.SetParent(curslots[i].transform);
                    itemobj.transform.position = curslots[i].transform.position;

                    item data = curslots[i].transform.GetChild(0).GetComponent<item>();
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();

                    break;
                }
            }
        }
    }
    bool CheckIfItemIsInInventory(Item item)
    {
        for (int i = 0; i < curitems.Count; i++)
            if (curitems[i].ID == item.ID)
                return true;
        return false;
    }

    public void select_test(){

        if(Input.GetKeyDown(KeyCode.Z)){
            if(selected.activeInHierarchy==false){
            if(curslots[S_index].transform.childCount > 0){
            select_b=true;
            selected.SetActive(true);
            selected.GetComponent<RectTransform>().anchoredPosition=curslots[S_index].GetComponent<RectTransform> ().anchoredPosition;
            selected_change=curitems[S_index]; //紀錄被選擇的
            selected0_index=S_index;

            }
            }else if(selected.activeInHierarchy==true){
                if(curslots[S_index].transform.childCount > 0){
                    selected.SetActive(false);
                    curitems[selected0_index]=curitems[S_index];
                    curitems[S_index]=selected_change;

                } else if (curslots[S_index].transform.childCount == 0)
                {
                    selected.SetActive(false);
                    curitems[S_index] = curitems[selected0_index];
                    curitems[selected0_index] = database.FetchItemByID(-1);
                    GameObject game0 = curslots[selected0_index].transform.GetChild(0).gameObject;
                    game0.GetComponent<item>().slot_id = S_index;
                    game0.transform.SetParent(curslots[S_index].transform);
                    game0.transform.position = curslots[S_index].transform.position;
                }

            }
        }
        if(Input.GetKeyDown(KeyCode.X)){
            if(selected.activeInHierarchy==true){
                selected.SetActive(false);
            }
        }
		if (curslots[S_index].transform.childCount > 0) {
			title_text.GetComponent<Text> ().text = curslots[S_index].transform.GetChild(0).GetComponent<item>().item_what.Title.ToString ();
			info_text.GetComponent<Text> ().text = curslots[S_index].transform.GetChild(0).GetComponent<item>().item_what.Information.ToString ();
		} else {
			title_text.GetComponent<Text> ().text = "nothing";
			info_text.GetComponent<Text> ().text = "nothing";
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (S_index < slotAmount-1) {
				S_index++;
				Vector2 slot_t = curslots[S_index].GetComponent<RectTransform> ().anchoredPosition;
				select_tranform.anchoredPosition = slot_t;
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
		if (S_index >0) {
				S_index--;
				Vector2 slot_t = curslots[S_index].GetComponent<RectTransform> ().anchoredPosition;
					select_tranform.anchoredPosition = slot_t;
				}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (S_index < slotAmount-4) {
				S_index +=4;
				Vector2 slot_t = curslots[S_index].GetComponent<RectTransform> ().anchoredPosition;
				select_tranform.anchoredPosition = slot_t;
			}
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (S_index >3) {
				S_index -=4;
				Vector2 slot_t = curslots[S_index].GetComponent<RectTransform> ().anchoredPosition;
				select_tranform.anchoredPosition = slot_t;
			}
		}
	}
}
/*
 bool c(){ //確認物品欄有沒有物品
        for (int i = 0; i < curitems.Count; i++){
            if(curitems[i].ID != -1)
            {
                return true;
            }
        }
        return false;
    }
  public void AddItem(int id)
    {
        int check = -1;
        Item itemToAdd = database.FetchItemByID(id);
        for (int i = 0; i < curitems.Count; i++)
        {   
            if(c()){  //有物品
                if(curitems[i].ID!=-1){  // 不是-1則要測試不是同一個
                if(curitems[i].ID==id){ //  如果都沒有同樣的id，則會跳0
                     check=0;
                      break;  //確定是則會跳出
                }
                else //  如果都沒有同樣的id，則會新增 跳1
                {
                    check=1;

                }
            }
            }else if(!c())  //沒物品
            {
                check=1;
                break;
            }
        }
        switch (check)
        {
            case 0:
                for (int i = 0; i < curitems.Count; i++)  // 計算擷取該物件裡面的數量數字
                {
                    if (curitems[i].ID == id)
                    {
                        item data = curslots[i].transform.GetChild(0).GetComponent<item>();
                        data.amount++;
                        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                        break;
                    }
                }
                break;

            case 1:
                for (int i = 0; i < curitems.Count; i++)
                {
                    if (curitems[i].ID == -1)
                   {
                        curitems[i] = itemToAdd; //輸入物品的id
                        GameObject itemobj = Instantiate(inventoryitem);  //複製新的gameobject
                        itemobj.GetComponent<item>().item_what = itemToAdd;  //gameobject 物件為什麼
                        itemobj.GetComponent<item>().slot_id = i;
                        itemobj.transform.SetParent(curslots[i].transform);
                        itemobj.transform.position = curslots[i].transform.position;
                        itemobj.name = itemToAdd.Title;
                        itemobj.GetComponent<Image>().sprite =itemToAdd.Sprite;

                    item data = curslots[i].transform.GetChild(0).GetComponent<item>();
                        data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();

                        break;
                    }
                }
                break;
        }
    }

    */
