using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {

    public GameUI gui;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            gui.Win();
    }
}
