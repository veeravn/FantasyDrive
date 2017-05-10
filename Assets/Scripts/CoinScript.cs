using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
       // print("inside trigger");
        GameObject parent = other.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        if (parent.name == "Car")
        {
          //  print("inside if");
            parent.GetComponent<CountDownTimer>().timeRemaining += 15;
            gameObject.SetActive(false);
        }


    }
}
