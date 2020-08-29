using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changtranform : MonoBehaviour {
    public GameObject[] spawnPoint;
    public GameObject player;
    public string iswho_scene = null;  //偵測角色是誰
    private void Awake()
    {
        player = GameObject.Find("player");
        switch (whereSpawn.where)
        {
            case 0:
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
                break;
            case 1:
                player.transform.position = new Vector2(spawnPoint[0].transform.position.x, spawnPoint[0].transform.position.y);
                break;
            case 2:
                player.transform.position = new Vector2(spawnPoint[1].transform.position.x, spawnPoint[0].transform.position.y);
                break;
            case 3:
                player.transform.position = new Vector2(spawnPoint[2].transform.position.x, spawnPoint[0].transform.position.y);
                break;
            case 4:
                player.transform.position = new Vector2(spawnPoint[3].transform.position.x, spawnPoint[0].transform.position.y);
                break;
            case 5:
                player.transform.position = new Vector2(spawnPoint[4].transform.position.x, spawnPoint[0].transform.position.y);
                break;

        }
    }

}
