using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MazeWin : MonoBehaviour
{
	public GameObject menu;
    public Text mazeFin;
    //public GameObject camera;
    private bool finished = false;
    // Use this for initialization
    void Start()
    {
		//menu.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            return;
        }
        
    }

    public void Finish()
    {
        finished = true;
        if ("Car" == this.gameObject.name)
        {
            if (mazeFin.text == "AI Won" || mazeFin.text == "Good job on Second place... NOT")
            {
                mazeFin.text = "Good job on Second place... NOT";
            }
            else
            {
                mazeFin.text = "You Won";
            }
        }
        else
        {
            mazeFin.text = "AI Won";
           // GameObject.Find("Car").SetActive(false);
        }
      //  camera.transform.position = new Vector3(-0.082f, 1.147f, -1.625f);
       /* if(mazeFin.text.Length!=0)
        {
      
            GameObject.Find("Car").SetActive(false);
        }
        else
        {
            mazeFin.text = "You Won";
        }*/
		menu.SetActive (true);
    }
}