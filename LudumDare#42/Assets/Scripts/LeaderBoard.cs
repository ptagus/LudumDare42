using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public List<Text> leaderboard;
    int n = 10;
	void Start ()
    {

	}

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Z))
        {
            n++;
            Scores.NewScore("first", n);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            FillTheLeaderboard();
        }
	}

    public void FillTheLeaderboard()
    {
        for(int i=0; i < leaderboard.Count; i++)
        {
            leaderboard[i].text = Scores.name[i] + "               "+ Scores.scores[i];
        }
    }
}

public static class Scores
{
    public static string[] name = new string[10];
    public static int[] scores = new int[10];
    public static string[] score = new string[10];

    public static void NewScore(string n, int s)
    {
        for(int i=0; i<10;i++)
        {
            if (s > scores[i])
            {
                for(int j = 8; j >= i; j--)
                {
                    name[j + 1] = name[j];
                    scores[j + 1] = scores[j];
                }
                name[i] = n;
                scores[i] = s;
                return;
            }
        }
    }
}
