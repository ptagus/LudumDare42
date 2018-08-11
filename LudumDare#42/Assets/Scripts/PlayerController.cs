using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float sensitivity = 5f;
    public float maxYAngle = 10f;
    public float maxXAngle = 60f;
    public GameObject GravitySphere;
    private Vector2 currentRotation;
    bool weapon;
    Ray r;
    RaycastHit rayhit;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = false;
        }
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -maxXAngle, maxXAngle);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        if (Input.GetMouseButtonDown(0))
        {
            if (weapon)
            {
                r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out rayhit, 100))
                {
                    if (rayhit.collider != null)
                    {
                        Debug.Log(rayhit.collider.name);
                        Debug.Log(weapon);
                        Shoot(rayhit.collider.gameObject);
                    }
                }
            }
            else
            {
                Instantiate(GravitySphere, transform.position, Quaternion.identity, this.transform);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.1f);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0.1f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0.1f);

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
    }    

    public void StopTake()
    {

    }

    void Shoot(GameObject t)
    {
        if (weapon)
        {
            t.GetComponent<AsteroidsBehavior>().NewShipPosition(transform);
        }
    }
}
