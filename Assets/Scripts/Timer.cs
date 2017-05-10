using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    
	public Text timer;
    public Text checkpointLabel;
    public bool AIWon = false;
	private float startTime;
	private bool finished = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (finished) {
			return;
		}
		float t = Time.time - startTime;
		string minutes = ((int)t / 60).ToString ();
		string seconds = (t % 60).ToString ("f2");
		timer.text = minutes + ":" + seconds;
	}

	private void onTriggerEnter(Collider other) {
        GameObject parent = null;
        print("hello");
        print(other.name);
        if (other.name == "Car_Collider")
        {
            parent = other.gameObject.transform.parent.gameObject;
            print("finished");
            Finish();
        }
        else
        {
            parent = other.gameObject.transform.parent.gameObject.transform.parent.gameObject;
            if(parent.name == "EYEmaginaryCar")
            {
                print("AI WON");
                Finish();
            }
        }
        
	}
	public void Finish() {

		GameObject go = GameObject.Find ("Car_Base");
        int cps = PlayerPrefs.GetInt("CheckPoints");
        if(cps == 4)
        {
            finished = true;

            timer.color = Color.red;
            checkpointLabel.color = Color.red;
            if (!AIWon)
            {
                checkpointLabel.text = "User Won";
                GameObject.Find("EYEmaginary").GetComponent<Timer>().finished = true;
                return;
            }
            else
            {
                checkpointLabel.text = "User Lost";
                GameObject.Find("EYEmaginary").GetComponent<Timer>().finished = true;
                return;

            }
            //added code to set value in PlayerPrefs
            PlayerPrefs.SetString("Player", timer.text.ToString());
            PlayerPrefs.Save();
        }

        if (AIWon)
        {
            //GameObject.Find("Car_Base").GetComponent<Timer>().finished = true;
            GameObject.Find("Car_Base").GetComponent<Timer>().AIWon = true;
            timer.color = Color.green;
            checkpointLabel.color = Color.green;
            checkpointLabel.text = "AI Won";
            finished = true;
        }

    }
}
