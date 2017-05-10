using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        
        GameObject parent = other.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        if (parent.name == "Car")
        {
            parent.GetComponent<CountDownTimer>().timeRemaining -= 15;
            gameObject.SetActive(false);
        }


    }
}

