using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeinout_public : MonoBehaviour {
	public float fadeInSpeed = 6f;
    float contorl_a ;
    inventory3_noglobal inv_no;
    public bool check_end;
    // Use this for initialization
    void Start () {
        inv_no = GetComponent<inventory3_noglobal>();
        contorl_a = 0;
    }

	public void fade_o(Image test_image){
        StartCoroutine(fade_out(test_image));
    }
	public void fade_i(Image test_image){
        StartCoroutine(fade_input(test_image));
    }
    IEnumerator fade_out(Image test_image) {
        if (test_image.color.a > -1f)
        {
            //float contorl_a=test_image.color.a;
            test_image.color = new Color(test_image.color.r, test_image.color.g, test_image.color.b, contorl_a);
            contorl_a -= Time.deltaTime * fadeInSpeed;
        }
        yield return new WaitForSeconds(0.5f);
        check_end = false;
    }
    IEnumerator fade_input(Image test_image)
    {
        if (test_image.color.a < 1.1f)
        {
            test_image.color = new Color(test_image.color.r, test_image.color.g, test_image.color.b, contorl_a);
            contorl_a += Time.deltaTime * fadeInSpeed;
        }
        yield return new WaitForSeconds(0.5f);
        check_end = true;
    }


}
