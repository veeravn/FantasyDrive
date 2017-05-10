using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDownTimer : MonoBehaviour {
   public float timeRemaining = 90;

    // time variables
    public static int allowedTime = 90;
    public int currentTime = allowedTime;
    public bool endGame = false;

    //added text
    public Text win;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(!endGame) timeRemaining -= Time.deltaTime;
    }
        
    void OnGUI()
    {
        // update the textfield
        if (timeRemaining > 0)
        {
            //  GUI.Label(new Rect(100, 100, 200, 100), "Time Remaining " + timeRemaining.ToString("f0"));
            if (!endGame) win.text = "Time Remaining " + timeRemaining.ToString("f0");
            
        }
        else
        {
            //  GUI.Label(new Rect(100, 100, 200, 100), "Time is UP!!");
            win.text = "Time is UP!!";
        }
    }
}
