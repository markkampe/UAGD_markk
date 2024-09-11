/*
 * Unity Associate Game Developer course - Unit 2
 *
 * This script causes the camera to follow the player,
 *      from a fixed distance behind
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;	// TRICK: to be added from Inspector
    private Vector3 offset;	// distance from camera to Player

    // Start is called before the first frame update
    void Start() {
	// note initial distance between camera and player
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame, AFTER all other Updates
    void LateUpdate() {
	// move us to the corresponding place behind the player
        transform.position = player.transform.position + offset;
    }
}
