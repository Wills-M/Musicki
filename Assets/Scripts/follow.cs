using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

    //Script for debug uses.

	public Rigidbody2D target;
	public float distance;

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		transform.position = new Vector3 (target.position.x, target.position.y, distance);
	}

}
