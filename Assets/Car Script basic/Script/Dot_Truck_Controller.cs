using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Dot_Truck : System.Object
{
	public WheelCollider leftWheel;
	public GameObject leftWheelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWheelMesh;
	public bool motor;
	public bool steering;
    public bool reverseTurn; 

}

public class Dot_Truck_Controller : MonoBehaviour {

	public float maxMotorTorque;
	public float maxSteeringAngle;
	public List<Dot_Truck> truck_Infos;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller2;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)controller2.index); } }
    private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;


    void Start()
    {
        controller2 = gameObject.GetComponent<SteamVR_TrackedObject>();
        //rb = GetComponent<Rigidbody>();
       // print("Test index: " + controller2.isValid);
        //print("Test index: " + (int)controller2.index);
    }




    public void VisualizeWheel(Dot_Truck wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.leftWheel.GetWorldPose ( out pos, out rot);
		wheelPair.leftWheelMesh.transform.position = pos;
		wheelPair.leftWheelMesh.transform.rotation = rot;
		wheelPair.rightWheel.GetWorldPose ( out pos, out rot);
		wheelPair.rightWheelMesh.transform.position = pos;
		wheelPair.rightWheelMesh.transform.rotation = rot;
	}

	public void Update()
	{
        device = SteamVR_Controller.Input((int)controller2.index);
        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float motor = maxMotorTorque * device.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger).x;

        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float steering = maxSteeringAngle * device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad).x;

        //float brakeTorque = Mathf.Abs(Input.GetAxis("Jump"));
        float brakeTorque;
        bool ifBrakeTorque = device.GetPress(EVRButtonId.k_EButton_Grip);

        //print("Trigger value" + device.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger));
       // print("Grip Pad Value is" + device.GetPress(EVRButtonId.k_EButton_Grip));
        
        //print("Vertical input value:"+ Input.GetAxis("Vertical"));
        //print("HoVerticalrizontal input value:" + Input.GetAxis("Horizontal"));
        //print("Jump value:" + Mathf.Abs(Input.GetAxis("Jump")));
       
        if (ifBrakeTorque) {
			brakeTorque = maxMotorTorque * 50;
			motor = 0;
		} else {
			brakeTorque = 0;
		}

		foreach (Dot_Truck truck_Info in truck_Infos)
		{
			if (truck_Info.steering == true) {
				truck_Info.leftWheel.steerAngle = truck_Info.rightWheel.steerAngle = ((truck_Info.reverseTurn)?-1:1)*steering;
			}

			if (truck_Info.motor == true)
			{
				truck_Info.leftWheel.motorTorque = motor;
				truck_Info.rightWheel.motorTorque = motor;
			}

			truck_Info.leftWheel.brakeTorque = brakeTorque;
			truck_Info.rightWheel.brakeTorque = brakeTorque;

			VisualizeWheel(truck_Info);
		}

        bool menuButtonPressed = controller.GetPress(menuButton);

        if (menuButtonPressed)
        {
            SceneManager.LoadScene("Menu 3D");
        }

    }


}