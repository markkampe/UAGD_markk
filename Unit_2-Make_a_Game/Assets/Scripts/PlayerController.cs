using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;	// controllable from Inspector
    private Rigidbody rb;	// Player sphere
    private float movementX;	// last X acceleration
    private float movementY;	// last Y acceleration

    // Start is called before the first frame update
    void Start() {
    	// get reference to player's Rigidbody
        rb = GetComponent <Rigidbody>();
    }

    // called once per fixed frame-rate frame
    private void FixedUpdate() {
    	// apply the latest movement vector to our Rigidbody
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // called whenever curor motion is received
    void OnMove( InputValue movementValue ) {
    	// save X and Y accelerations for next update
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
