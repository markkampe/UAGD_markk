using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start() {
	// note initial distance between camera and player
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame, after all other Updates
    void LateUpdate() {
	// move us to the corresponding place behind the player
        transform.position = player.transform.position + offset;
    }
}
