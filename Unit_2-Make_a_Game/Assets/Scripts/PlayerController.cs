/*
 * Unity Associate Game Developer course - Unit 2
 *
 * This script:
 *    1	reads cursor key presses, and turns them into
 * 	accelerations of the Player sphere (to which this script
 * 	is a component)
 *    2 detects collisions with PickUp objects, deactivates
 *	them, and bumps the score.
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
    private int numObjects;	// number of objects to pick up
    private float movementX;	// last left/right acceleration
    private float movementY;	// last forwards/backwards acceleration
    private bool gameOver = false;	// we have won (or lost)

    // input parameters set from Inspector
    public float speed = 0;		// player speed

    // object references ... set from explorer (rather than searched)
    public TextMeshProUGUI countText;	// score board object
    public GameObject winTextObject;	// You Won announcment
    public GameObject pickupFX;		// small box burst
    public AudioSource ching;		// pick-up box sound
    public AudioSource winMusic;	// you won sound
    public GameObject victoryFX;	// snow-fall
    public GameObject smokeTrail;	// smoke particle system
    public AudioSource backgroundMusic;	// background: set from Inspector

    // Start is called before the first frame update
    void Start() {
    	// figure out how many Pick-Up items there are
    	GameObject[] pickups;
	pickups = GameObject.FindGameObjectsWithTag("PickUp");
	foreach (GameObject pu in pickups)
	    numObjects++;

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
	// any time he enters Escape, the game is over
	if (Input.GetKey(KeyCode.Escape)) {
#if UNITY_EDITOR
	    UnityEditor.EditorApplication.isPlaying = false;
#else
	    Application.Quit();
#endif
	}

	// if we are done or he hit space, stop us
	if (gameOver || Input.GetKey(KeyCode.Space)) {
	    rb.velocity = Vector3.zero;
	    return;
	}

	// otherwise, accelerate based on current cursor input
	Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
	rb.AddForce(movement * speed);

    	// drop occasional smoke trails
	Instantiate(smokeTrail, transform.position, Quaternion.identity);
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
     *	 if we have gotten the last one, we win, destroy enemy
     */
    void OnTriggerEnter(Collider other) {
	// disable any PickUp we collide with
	if (other.gameObject.CompareTag("PickUp")) {
	    other.gameObject.SetActive(false);

	    // score celebratory burst (for 3 seconds)
	    ching.Play(0);
	    var currentPickupFX = Instantiate(pickupFX, transform.position, Quaternion.identity);
	    Destroy(currentPickupFX, 3);

	    // give us credit for the score
    	    count++;
	    SetCountText();
	    if (count >= numObjects) {
	    	winTextObject.SetActive(true);
		Destroy(GameObject.FindGameObjectWithTag("Enemy"));

	    	// celebratory fireworks
	    	Instantiate(victoryFX, transform.position, Quaternion.identity);
	    	winMusic.Play(0);

		// turn off game activities
		shutDown();
	    }
	}
    }

    /*
     * called whenever someone (e.g. an enemy) collides with us
     *	  we have lost
     */
    private void OnCollisionEnter(Collision collision) {
    	if (collision.gameObject.CompareTag("Enemy")) {
	    // display "You Lose!"
	    winTextObject.gameObject.SetActive(true);
	    winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";

	    // turn off game activities
	    shutDown();

	    // destroy player (notifying enemy of his win)
	    Destroy(gameObject, 0.5f);
	}
    }

    /*
     * called when game is over (win or lose)
     *	      shut down music and player motion
     */
    private void shutDown() {
    	// stop the background music
	backgroundMusic.Stop();

	// disable further player motion
	gameOver = true;
    }
}
