using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffRoad : MonoBehaviour {

    private void OnCollisionEnter(Collision other)
    {
        print("test1");
        if (other.gameObject.name == "Terrain")
        {
            print("test1");
            //GameObject.Find("Controller (left)").GetComponent<Controller>().playerSpeed = 10F;
            //GameObject.Find("Controller (right)").GetComponent<Controller>().playerSpeed = 10F;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Terrain")
        {
            print("test1");
           // GameObject.Find("Controller (left)").GetComponent<Controller>().playerSpeed = -50F;
           // GameObject.Find("Controller (right)").GetComponent<Controller>().playerSpeed = -50F;
        }
    }
}
