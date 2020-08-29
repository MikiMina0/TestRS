using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour {
    private GameObject Canvas;
    public GameObject Loading_panel;
    public GameObject loadText;
    public GameObject loadimage;
    public GameObject scene_name;

    public Text loadText_text;
    public Text scenename_text;
    private Image text_Color;
    private Image loadimage_image;
    //private Image Loading_panel_Color;
    private Animator loading_anim,scene_anim;
    public TextAsset scene_txt;
    float T_a;
    public float fadeInSpeed = 4.0f;
    public float time, time_i;
    public Animationcontorler player;
    public string[] scene_name_string;

    void Start () {
        Canvas = GameObject.Find("Canvas");
        Loading_panel = Canvas.transform.Find("loading_panel").gameObject;
        loadText = Loading_panel.transform.GetChild(0).gameObject;
        loadimage = Loading_panel.transform.GetChild(1).gameObject;
        scene_name = Loading_panel.transform.GetChild(2).gameObject;
        //
        loadText_text = loadText.GetComponent<Text>();
        scenename_text = scene_name.GetComponent<Text>();
        //text_Color = loadText.GetComponent<Image>();
        //
        //Loading_panel_Color = Loading_panel.GetComponent<Image>();
        loadimage_image = loadimage.GetComponent<Image>();
        loading_anim = Loading_panel.GetComponent<Animator>();
        scene_anim = scenename_text.GetComponent<Animator>();
        //
        T_a = 0;
        loadText_text.color = new Color(loadText_text.color.r, loadText_text.color.g, loadText_text.color.b, T_a);
        loadimage_image.color = new Color(loadimage_image.color.r, loadimage_image.color.g, loadimage_image.color.b, T_a);

        Debug.Log(scenename_text.color.a);
        loadText.SetActive(false);
        loadimage.SetActive(false);
        //scene_name.SetActive(false);

        scene_txt = Resources.Load<TextAsset>("scene_name_txt/scene_name_txt");
        player = Animationcontorler.play_ins.gameObject.GetComponent<Animationcontorler>();
        player.canmove = true;
        time_i = 0;
        scene_name_t(scene_txt);
    }

    // Update is called once per frame
    void Update () {
       // StartCoroutine(Displayerscenename(scenename_text));

        if (loadText.activeInHierarchy == true && loadimage.activeInHierarchy == true)
        {
                if (loadText_text.color.a < 1.1f)
                {
                    T_a += Time.deltaTime * fadeInSpeed;
                    loadText_text.color = new Color(loadText_text.color.r, loadText_text.color.g, loadText_text.color.b, T_a);
                    loadimage_image.color = new Color(loadimage_image.color.r, loadimage_image.color.g, loadimage_image.color.b, T_a);
                  //  scenename_text.color = new Color(scenename_text.color.r, scenename_text.color.g, scenename_text.color.b, T_a);
            }
        }
        time = Time.time;
    }
    public void loadingachangescene(int scene)
    {
        if (time - time_i > 10f || time_i == 0)
        {
            StartCoroutine(DisplayLoadingScreen(scene));
            time_i = time;
        }
    }
    void scene_name_t(TextAsset scenename)
    {
        scene_name_string = scenename.text.Split('\n');
    }

    /* IEnumerator tt()
     {
         loading_anim.SetTrigger("end");
         yield return new WaitForSeconds(5f);
     }*/

    IEnumerator DisplayLoadingScreen(int sceneName)////(1)
    {
        player.canmove = false;
        int displayPregree = 0;
        int toProgress = 0;
        loading_anim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        loadText.SetActive(true);
        loadimage.SetActive(true);

        // while (Color.color.a ==1) {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);////(2)
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)////(3)
            {
                toProgress = (int)async.progress * 100;

                while (displayPregree < toProgress)
                {
                    displayPregree++;
                    setLoading(displayPregree);
                    yield return new WaitForEndOfFrame();
                }
                toProgress = 100;
                while (displayPregree < toProgress)
                {
                    displayPregree++;
                    setLoading(displayPregree);
                    yield return new WaitForEndOfFrame();
                }
            }
        yield return new WaitForSeconds(0.5f);
        async.allowSceneActivation = true;
        loading_anim.Play("loadingpanel_start", -1, 0f);
        scene_anim.Play("scene_F", -1, 0f);
        scenename_text.text = scene_name_string[sceneName];
        /*  if (async.progress > 0.5)
          {
              Debug.Log("!");
          }  */
        // }

    }

    private void setLoading(float percent)
    {
        loadText_text.text = percent.ToString() + "%";
    }
}
