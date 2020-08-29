using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaracontrol : MonoBehaviour {

    public GameObject followTarget;
    private GameObject Bound;
    //private GameObject C;
    private Vector3 targetPos;
    public float moveSpeed;

    private static bool cameraExists;
    public BoxCollider2D boundbox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;



	// Use this for initialization
	void Start () {
     //   C = this.gameObject;
        followTarget = GameObject.Find("player");
        Bound = GameObject.Find("Bound");
        boundbox = Bound.GetComponent<BoxCollider2D>();

        minBounds = boundbox.bounds.min;
        maxBounds = boundbox.bounds.max;

        theCamera = GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        transform.position= new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y + 0.37f);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
