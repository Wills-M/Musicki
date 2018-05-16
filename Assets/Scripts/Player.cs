using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float moveSpeed = 1f;                 // Amount of move in your move
    public float jumpForce = 1f;			// Amount of force added when the player jumps.
    public float jumpDirLerp = 1f;

    public static bool grounded = false;			// Whether or not the player is grounded.
    public static bool hanging = false;
    public static bool jumpInput = false;
    public static Vector2 collNormal;

    private bool right = false;             // Are we moving right?
    private bool left = false;              // Are we moving left?
    private Vector2 jumpDirection;
    private Rigidbody2D myRB;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = GameCamera.myCam.WorldToViewportPoint(myRB.transform.position);
        if (screenPos.x < 0.0 || screenPos.x > 1.0 || screenPos.y < 0.0) // Player is out of bounds
            kill();

        // Are we moving?
        if (Input.GetKey(KeyCode.D))
            right = true;
        else
            right = false;
        if (Input.GetKey(KeyCode.A))
            left = true;
        else
            left = false;
        if (Input.GetKey(KeyCode.Escape))
            Application.LoadLevel(0);

    }
    
    //Fixed Update fer all yer physics needs
    void FixedUpdate()
    {

        if (right)
            myRB.AddForce(Vector2.right * moveSpeed);
        if (left)
            myRB.AddForce(Vector2.left * moveSpeed);

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            jumpInput = true;
            if (grounded)
            {
                // Add a vertical force to the player.
                myRB.AddForce(jumpDirection * jumpForce);
                // Make sure the player can't jump again until the jump conditions from Update are satisfied.
                grounded = false;

            }

            if (hanging)
            {
                // KEEP THIS FOR NOW BECAUSE IT MIGHT COME IN HANDY LATER
                //Vector2 stick;
                //stick = new Vector2(-1 * collNormal.x, -1 * collNormal.y);
                //myRB.AddForce(stick * 100f);
                myRB.gravityScale = -1;
                hanging = false;
            }
            else
                myRB.gravityScale = 5;
        }
        else 
            jumpInput = false;

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
            myRB.gravityScale = 10;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        grounded = coll.gameObject.tag == "Ground";
        hanging = coll.gameObject.tag == "Cieling";

        if (coll.gameObject.tag == "win")
            Application.LoadLevel(2);

        collNormal = coll.contacts[0].normal;
        jumpDirection = Vector2.Lerp(collNormal, new Vector2(0,1), jumpDirLerp);
    }

    void onCollisionExit2D(Collision2D coll)
    {
        grounded = coll.gameObject.tag == "Ground";
        hanging = coll.gameObject.tag == "Cieling";
    }

    public static void kill()
    {
        GameCamera.move = false;

        Application.LoadLevel(1);
    }

}
