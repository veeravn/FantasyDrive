using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoints : MonoBehaviour {
    private int pointsPassed;
    private bool UserWon = false;
    void Start()
    {

        PlayerPrefs.SetInt("CheckPoints", 0);
        PlayerPrefs.Save();
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject parent = null;

        if (other.name == "Car_Collider")
        {
            parent = other.gameObject.transform.parent.gameObject;
        } else
        {
            parent = other.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        }
        if (parent.name == "Car_Base")
        {
            this.gameObject.transform.parent.gameObject.SetActive(false);
            print("check");
            Text label = GameObject.FindWithTag("CheckPointLabel").GetComponent<Text>();
            pointsPassed = PlayerPrefs.GetInt("CheckPoints");

            if (pointsPassed == 4)
            {
                print("Finish");
                UserWon = true;
                parent.GetComponent<Timer>().Finish();
                return;
                
            }

         
            pointsPassed++;
            PlayerPrefs.SetInt("CheckPoints", pointsPassed);
            PlayerPrefs.Save();
            label.text = "Passed " + pointsPassed + " CheckPoints";
        }
        else
        {
            if(this.name == "EndLineTrigger")
            {
                if (!UserWon)
                {
                    parent.GetComponent<Timer>().AIWon = true;
                    parent.GetComponent<Timer>().Finish();
                }
            }
        }
        
        
    }

}
