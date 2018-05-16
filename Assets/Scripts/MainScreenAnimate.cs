using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenAnimate : MonoBehaviour {

	public float movefast = 1;

	// Use this for initialization
	void Start () {
		Debug.Log (transform.localPosition);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.x >= 802) {
			transform.localPosition = new Vector2 (-798, transform.localPosition.y);
		}
		else
			transform.localPosition = new Vector2 (transform.localPosition.x + movefast, transform.localPosition.y);
		
		
	}
}
