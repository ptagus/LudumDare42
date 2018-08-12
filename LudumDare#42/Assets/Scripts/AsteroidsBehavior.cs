using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehavior : MonoBehaviour {

    public AsteroidTypes at;
    bool toShip;
    Transform ShipPosition;
    // Use this for initialization
    private void Awake()
    {
        if(Random.Range(1,100) > 80)
        {
            at = AsteroidTypes.Energy;
            return;
        }
        at = AsteroidTypes.Simple;
    }

    // Update is called once per frame
    void Update ()
    {
		if (toShip)
        {
            transform.position = Vector3.Lerp( ShipPosition.position, transform.position, 0.9f);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && at == AsteroidTypes.Simple)
        {
            GameObject.Find("GameUI").GetComponent<GameUI>().Death();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shield")
        {
            GameObject.Find("GB").GetComponent<Gamebehavior>().AsteroidInShip(0.2f);
        }
        if (collision.collider.tag == "Asteroid")
        {
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {

    }

    public void NewShipPosition(Transform t)
    {
        ShipPosition = t;
        toShip = true;
        Destroy(this.gameObject, 0.5f);
    }
}

public enum AsteroidTypes
{
    Energy,
    Simple
}
