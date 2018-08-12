using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamebehavior : MonoBehaviour
{
    [Header("Ship")]
    public float speed;
    public float energy;
    [Space(10)]
    [Header("GameParametrs")]
    public float points = 0;
    public float distance;
    public float energydownspeed;
    [Space(10)]
    [Header("GameComponents")]
    public Slider energySlider;
    public bool shieldstatus;
    public TextMeshProUGUI pointstext;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        points += Time.deltaTime;
        pointstext.text = "Points: " + points.ToString("#");
        energySlider.value += Time.deltaTime * energydownspeed;
        if (energySlider.value >= 1)
        {
            GameObject.Find("GameUI").GetComponent<GameUI>().Death();
        }
	}

    public void ShieldStatusUpdate(bool status)
    {
        shieldstatus = status;
        if (status)
        {
            energydownspeed *= 2;
            return;
        }
        energydownspeed *= 0.5f;
    }

    public void GravityWeaponShoot(float cost)
    {
        energySlider.value += cost;
    }

    public void AsteroidInShip(float damage)
    {
        energySlider.value += damage;
    }

    public void EnergyAsteroid(float energycount)
    {
        energySlider.value -= energycount;
    }
}
