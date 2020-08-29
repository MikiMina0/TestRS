using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using LitJson;

public class save_test : MonoBehaviour {
    private inventory3_noglobal inv3_no;
    Itemdata database;
    JsonData d_j;
    int[] amount;
    private string jsonString;
    private JsonData jsonData_load;
    int[] item_load;
    int[] item_load_a;
    void Start() {
        inv3_no = GetComponent<inventory3_noglobal>();
        database = GetComponent<Itemdata>();
        item_load= new int[12];
        item_load_a= new int[12];
        amount=new int[12];
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            load();
            Debug.Log("loadfinish");

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            save();
            Debug.Log("savefinish");
        }
    }

    public void save() {
        for(int i = 0; i < 12; i++){
            if(inv3_no.curslots[i].transform.childCount > 0){
                amount[i]=inv3_no.curslots[i].transform.GetChild(0).GetComponent<item>().amount;
            }else
            {
                amount[i]=0;
            }
        }
        PlayerData data = new PlayerData(inv3_no.items_ID, amount,inv3_no.slotAmount);  //製作data
        d_j = JsonMapper.ToJson(data); //把data寫至json裡面
        File.WriteAllText(Application.dataPath + "/data01.json", d_j.ToString());  //寫成一個txt
    }
    public void load() {
       
        jsonString = File.ReadAllText(Application.dataPath + "/data01.json"); //讀取json的txt
          jsonData_load = JsonMapper.ToObject(jsonString); //把jsonstring弄成object
                                 
        for (int i = 0; i < 12; i++) {
            item_load[i]= int.Parse(jsonData_load["item"][i].ToString()); //讀取json裡面的擁有的物品種類
            item_load_a[i]=int.Parse(jsonData_load["item_a"][i].ToString()); //讀取json裡面的物品數量
             if (inv3_no.curitems[i].ID != item_load[i]) {
                 if (inv3_no.curitems[i].ID == -1 && item_load[i]!=-1)
                 {
                     inv3_no.curitems[i] = database.FetchItemByID(item_load[i]);
                     GameObject itemobj = Instantiate(inv3_no.inventoryitem);
                     itemobj.GetComponent<item>().slot_id = i;
                     itemobj.transform.SetParent(inv3_no.curslots[i].transform);
                     itemobj.transform.position = inv3_no.curslots[i].transform.position;
                     itemobj.GetComponent<item>().amount=item_load_a[i];
                     Debug.Log(itemobj.GetComponent<item>().amount);

                }
                if (inv3_no.curitems[i].ID != -1 && item_load[i] != -1)
                 {
                     inv3_no.curitems[i] = database.FetchItemByID(item_load[i]);
                     GameObject obj=inv3_no.curslots[i].transform.GetChild(0).gameObject;
                     obj.GetComponent<item>().amount=item_load_a[i];
                    Debug.Log(obj.GetComponent<item>().amount);
                }
                 if (inv3_no.curitems[i].ID != -1 && item_load[i] == -1)
                 {
                     Destroy(inv3_no.curslots[i].transform.GetChild(0).gameObject);
                 }
            }
            //    inv3_no.curitems[i].ID = item_load[i];
        }

    }

    }


public class PlayerData
{
    public int[] item;  //物品的數量
    public int[] item_a;
    public int slot_amount; //有幾格

    public PlayerData(int[] item,int[] item_a,int slot_amount) {
        this.slot_amount = slot_amount;
        this.item = new int[slot_amount];
        this.item_a=new int[slot_amount];
       for(int i=0;i<slot_amount;i++){ 
       this.item[i]=item[i];
       this.item_a[i]=item_a[i];
       }
   }

}
