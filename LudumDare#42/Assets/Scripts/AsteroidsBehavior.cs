using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehavior : MonoBehaviour {

    public Vector3 direction = Vector3.zero;
    public Vector3 directionrotate = Vector3.zero;
    public AsteroidTypes at;
    bool toShip;
    Transform ShipPosition;
    // Use this for initialization
    private void Awake()
    {
        if(Random.Range(1,100) > 80)
        {
            at = AsteroidTypes.Energy;
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            return;
        }
        at = AsteroidTypes.Simple;
        Destrotasteroids();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(direction);
        transform.Rotate(1,0,0);
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
        if (collision.collider.tag == "Shield" && at != AsteroidTypes.Energy)
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

    private void Destrotasteroids()
    {
        Destroy(this.gameObject, 20);
    }
}

public enum AsteroidTypes
{
    Energy,
    Simple
}
