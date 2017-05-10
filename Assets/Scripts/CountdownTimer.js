#pragma strict
import UnityEngine.UI;
// the textfield to update the time to
public var textfield:UnityEngine.UI.Text;

// time variables
public var allowedTime = 90;
public var currentTime = allowedTime;


function Awake()
{
    UpdateTimerText();	
    // start the timer ticking
    TimerTick();
}

function UpdateTimerText()
{
    // update the textfield
    //textfield.text = currentTime.ToString();
}


function TimerTick()
{
    // while there are seconds left
    /*
    while(currentTime > 0)
    {
        // wait for 1 second
        yield WaitForSeconds(1);
		
        // reduce the time
        currentTime--;
		
        UpdateTimerText();
    }
    */
	
    // game over
	
}