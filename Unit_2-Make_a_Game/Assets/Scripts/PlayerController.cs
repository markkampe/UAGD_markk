/*
 * Unity Associate Game Developer course - Unit 2
 *
 * This script:
 *    1	reads cursor key presses, and turns them into
 * 	accelerations of the Player sphere (to which this script
 * 	is a component)
 *    2 detects collisions with PickUp objects, deactivates
 *	them, and bumps the score.
 *
 * TODO:
 *	in Start, count the objects tagged as PickUp
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;	// Player sphere
    private int count;		// score of PickUps collected
    private float movementX;	// last left/right acceleration
    private float movementY;	// last forwards/backwards acceleration
    public float speed = 0;	// TRICK: set from the Inspector
    public int numObjects = 0;	// TRICK: set from inspector
    public TextMeshProUGUI countText;	// score board: set from Inspector
    public GameObject winTextObject;	// win anouncement: set from Inspector

    // Start is called before the first frame update
    void Start() {
	// score starts out zero
	count = 0;
	winTextObject.SetActive(false);

    	// get reference to player's Rigidbody
        rb = GetComponent <Rigidbody>();
    }

    /*
     * called once for every (fixed rate) frame update
     *
     *	Apply the latest current <x,y> values (status of cursor
     *  left/right/up/down buttons) to the Player RigidBody, 
     *  as an acceleration, on each update.
     *
     *	The total acceleration is a combination of the duration of
     *	the key press and the speed variable (which can be set
     *	from within the Inspector)
     */
    private void FixedUpdate() {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    /*
     * called whenever a cursor key goes down (or up)
     *
     *	  Save the (2D) X and Y components so they can be applied
     *	  to subsequent Updates.  
     *		on button-down movementValue will be non-zero
     *		on button-up movementValue will be <0,0>
     */
    void OnMove( InputValue movementValue ) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // update score display
    void SetCountText() {
    	countText.text = "Count: " + count.ToString();
    }

    /*
     * called whenever we collide with another RigidBody
     *	 if it was a PickUp, deactivate it and bump our score
     */
    void OnTriggerEnter(Collider other) {
	// disable any PickUp we collide with
	if (other.gameObject.CompareTag("PickUp")) {
	    other.gameObject.SetActive(false);
    	    count++;
	    SetCountText();
	    if (count >= numObjects)
	    	winTextObject.SetActive(true);
	}
    }
}