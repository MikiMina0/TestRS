using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_Application : MonoBehaviour {

    public string who2;
    public int scene;
    public int tranform;

    private changtranform talk;
    private loading loading;
    private Animationcontorler player;



    void Start()
    {
        talk = FindObjectOfType<changtranform>();
        loading = FindObjectOfType<loading>();
        player = FindObjectOfType<Animationcontorler>();

    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            talk.iswho_scene = who2;

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            if (player.isGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    whereSpawn.where = tranform;
                    //SceneManager.LoadScene(scene);
                    loading.loadingachangescene(scene);
                    //player.canmove = false;
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            talk.iswho_scene = null;

        }
    }

}
