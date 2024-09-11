/*
 * Unity Associate Game Developer - Unit 2
 *
 *   The purpose of this script is to cause PickUp
 *   objects to tumble (continuously about all 3 axes)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
	// continuous rotation with every update
        transform.Rotate( new Vector3(15,30,45) * Time.deltaTime);
    }
}
