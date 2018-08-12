using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public GameObject shield;
    public Image gravityWeapon;
    public Image telekinesWeapon;
    public Image deathscreen, winscreen;
    public Button shieldButton, shieldButton1, pause;
    public Text pointscount;
    int points = 0;
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (shieldButton.IsActive())
            {
                shieldButton.onClick.Invoke();
                return;
            }
            if (shieldButton1.IsActive())
            {
                shieldButton1.onClick.Invoke();
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.onClick.Invoke();
            return;
        }
	}

    public void ReastartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ShieldActivateorDeactivate(bool t)
    {
        shield.SetActive(t);
    }

    public void ActivateGravityCannon()
    {
        gravityWeapon.color = Color.green;
        telekinesWeapon.color = Color.red;
    }

    public void ActivateTelekinesCannon()
    {
        telekinesWeapon.color = Color.green;
        gravityWeapon.color = Color.red;
    }

    public void Death()
    {
        deathscreen.gameObject.SetActive(true);
    }

    public void Win()
    {
        winscreen.gameObject.SetActive(true);
    }

}
