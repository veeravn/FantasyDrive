using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CarCheckPoint : MonoBehaviour {
	public Transform[] checkPoints;
	public int currentCheckPoint = 0;
	void start() {
        currentCheckPoint = 0;


    }
}