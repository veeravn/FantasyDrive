using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GameObject parent;
        GameObject.Find("Car").GetComponent<CountDownTimer>().endGame = true;
        parent = other.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        print(parent.name);
        parent.SendMessage("Finish");
    }

}
