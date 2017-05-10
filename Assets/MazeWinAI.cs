using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MazeWinAI : MonoBehaviour
{
    public GameObject menu;
    public Text mazeFin;
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
        print("In AI finish");
        finished = true;
        mazeFin.text ="AI Won";
        menu.SetActive(true);
    }
}