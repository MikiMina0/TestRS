using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class Itemdata : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;
    public int[] k;

    // Use this for initialization
    void Start () {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/thing.json")); //物品種類的圖鑑
        ConstructItemDatabase();
        k=new int[4];
    }
    void Update() {
        for(int i = 0; i < 4; i++){
        k[i]=database[i].ID;
    } 
    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
            return database[i];           
        return null;
    }
    void ConstructItemDatabase(){
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(), itemData[i]["information"].ToString(), itemData[i]["slug"].ToString()));
        }
        }
}
public class Item
{
    public int ID { get;set;}//set;
    public string Title { get;set;}
    public string Information { get;set;}
    public string Slug { get;set;}
    public Sprite Sprite { get;set;}

    public Item(int id,string title,string information,string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Information = information;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Item/" + slug);
    }
     public Item()
    {
        this.ID = -1;
    } 
}
