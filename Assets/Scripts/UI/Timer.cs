﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour 
{
    [SerializeField]
    private Text timerText;

    public float timerCounter;
	private float seconds = 3f;

    private bool runTimer = false;

	void Start ()
	{
		StartCoroutine ("waitThreeSeconds");
	}

	IEnumerator waitThreeSeconds() 
	{
		yield return new WaitForSeconds (seconds);
        runTimer = true;
	}

	void Update () 
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();


        if (playerMovement.deathCounter <= 2)
        {
            TimerSet();
        }
		
    }

	void TimerSet ()
	{
        if (runTimer == true)
        {
            timerCounter += Time.deltaTime;

            var minutes = timerCounter / 60;
            var seconds = timerCounter % 60;
            var fraction = (timerCounter * 100) % 100;

            timerText.text = string.Format(" Time: {0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        }
		
    }
}
