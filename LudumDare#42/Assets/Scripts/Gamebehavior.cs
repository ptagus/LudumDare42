using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamebehavior : MonoBehaviour
{
    [Header("Ship")]
    public float speed;
    public float energy;
    [Space(10)]
    [Header("GameParametrs")]
    public int points;
    public float distance;
    Weapon activeWeapon;
    


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
