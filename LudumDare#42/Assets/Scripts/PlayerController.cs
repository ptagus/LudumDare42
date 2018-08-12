using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float reload = 3;
    public GameUI ui;
    public Gamebehavior GB;
    public float sensitivity = 5f;
    public float maxYAngle = 10f;
    public float maxXAngle = 60f;
    public GameObject GravitySphere;
    private Vector2 currentRotation;
    Weapon weapon = Weapon.Default;
    Ray r;
    RaycastHit rayhit;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (reload < 4)
        {
            reload += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = Weapon.GravityCannon;
            ui.ActivateGravityCannon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = Weapon.TelekinesWeapon;
            ui.ActivateTelekinesCannon();
        }
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -maxXAngle, maxXAngle);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        if (Input.GetMouseButtonDown(0) && reload > 3)
        {
            Debug.Log("Shoot");
            if (weapon == Weapon.TelekinesWeapon)
            {
                reload = 0;
                r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out rayhit, 100))
                {
                    if (rayhit.collider != null)
                    {                        
                        Shoot(rayhit.collider.gameObject);
                    }
                }
            }
            if (weapon == Weapon.GravityCannon)
            {
                reload = 0;
                GB.GravityWeaponShoot(0.1f);
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
        if (t.GetComponent<AsteroidsBehavior>().at == AsteroidTypes.Energy)
        {
            t.GetComponent<AsteroidsBehavior>().NewShipPosition(transform);
            GB.EnergyAsteroid(Random.Range(0.1f, 0.3f));
            return;
        }
    }
}
