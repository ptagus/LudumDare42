using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float x = 5 * Input.GetAxis("Mouse X");
        float y = 5 * -Input.GetAxis("Mouse Y");
        transform.Rotate(y, x, 0);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.1f);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.Translate(Vector3.zero);
        }
    }    
}
