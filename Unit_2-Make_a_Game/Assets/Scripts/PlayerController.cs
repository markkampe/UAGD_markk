/*
 * Unity Associate Game Developer course - Unit 2
 *
 * This script reads cursor key presses, and turns them into
 * accelerations of the Player sphere.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;	// Player sphere
    private float movementX;	// last left/right acceleration
    private float movementY;	// last forwards/backwards acceleration
    public float speed = 0;	// TRICK: set from the Inspector

    // Start is called before the first frame update
    void Start() {
    	// get reference to player's Rigidbody
        rb = GetComponent <Rigidbody>();
    }

    /*
     * called once for every (fixed rate) frame update
     *
     *	Apply the latest recorded <x,y> values to the Player
     *	RigidBody, as an acceleration, on each update.  The
     *	longer you hold the button down, the more it will
     *	accelerate in the indicated direction(s).
     *
     *	the acceleration is a combination of the duration of
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
     */
    void OnMove( InputValue movementValue ) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
