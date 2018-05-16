using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

    private Animator myAnimator;
    private Rigidbody2D myBody;

	// Use this for initialization
	void Start () {

        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        myAnimator.SetFloat("speed", myBody.velocity.x);
        myAnimator.SetBool("grounded", Player.grounded);
        myAnimator.SetBool("hanging", Player.hanging);
        myAnimator.SetBool("Jump Input", Player.jumpInput);
        if (Player.collNormal == Vector2.up)
            myAnimator.SetBool("onFlatGround", true);
        else
            myAnimator.SetBool("onFlatGround", false);
              
	}
}
