using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBoom : MonoBehaviour
{
    public List<Rigidbody> asteroids;
    // Use this for initialization
    void Start()
    {
        Invoke("GraviteExplosion", 1);
    }

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(Vector3.forward * 0.2f);
    }

    void GraviteExplosion()
    {
        GameObject.Find("GB").GetComponent<Gamebehavior>().points += 3 * asteroids.Count;
        foreach (Rigidbody rb in asteroids)
        {
            rb.AddExplosionForce(100, this.transform.position, 10, 10, ForceMode.Impulse);
        }
        Destroy(this.gameObject, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
            asteroids.Add(other.GetComponent<Rigidbody>());
    }
}