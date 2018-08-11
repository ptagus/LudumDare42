using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Range (0,1)]
    public float alpha = 0;
    float exalpha = 1;
    public Color c;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        c.a = alpha;
        Newalpha();
	}

    void Newalpha()
    {
        if (exalpha != alpha)
        {
            exalpha = alpha;
            GetComponent<Renderer>().material.color = c;
        }
        return;
    }
}
