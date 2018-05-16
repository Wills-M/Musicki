using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public static Camera myCam;
    public static bool move;
    public Vector3 cameraSpeed = new Vector3(26 / 60, 0, 0);
    public Vector3 start = new Vector3(0, 0, 0);

	// Use this for initialization
    void Start()
    {
        transform.position = transform.position - start;
        myCam = GetComponent<Camera>();
        move = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
		    transform.position = transform.position + cameraSpeed;
	}
}
