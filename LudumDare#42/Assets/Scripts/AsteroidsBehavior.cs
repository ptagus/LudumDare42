using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehavior : MonoBehaviour {

    bool toShip;
    Transform ShipPosition;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (toShip)
        {
            transform.position = Vector3.Lerp( ShipPosition.position, transform.position, 0.9f);
        }
	}

    public void NewShipPosition(Transform t)
    {
        ShipPosition = t;
        toShip = true;
    }
}
