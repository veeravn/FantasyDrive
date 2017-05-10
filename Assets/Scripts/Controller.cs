using UnityEngine;
using System.Collections;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
	public GameObject player;

	SteamVR_Controller.Device device;
	SteamVR_TrackedObject controller2;

	Vector2 touchpad;
	Vector2 trigger;
	public bool triggerButtonPressed;
	private float sensitivityX = 1.5F;
	private Vector3 playerPos;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)controller2.index); } }
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;
    int oldLayer = -1;
    int voidLayer;
    public float playerSpeed = -100f;
	void Start()
	{
		controller2 = gameObject.GetComponent<SteamVR_TrackedObject>();
        voidLayer = LayerMask.NameToLayer("Void");
        print("Test index: " +  controller2.isValid);
        print("Test index: " + (int)controller2.index);
	}

    void DisableCollider(Collider col)
    {
        oldLayer = col.gameObject.layer;
        col.gameObject.layer = voidLayer;
    }

    void EnableCollider(Collider col)
    {
        col.gameObject.layer = oldLayer;
    }

    // Update is called once per frame
    void Update()
	{
        
		device = SteamVR_Controller.Input((int)controller2.index);


		//*********Mukai's code********//
		//If clicked on touchpad
		if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
		{
			//Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
			touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);
			//print("Pressing Touchpad");

			//if (touchpad.y > 0.7f)
			//{
			//	print("Moving Up");
			//}

			 if (touchpad.y < -0.7f)
			{
				//print("Moving Down");
			}

			if (touchpad.x > 0.7f)
			{
				//print("Moving Right");
				player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
			}

			else if (touchpad.x < -0.7f)
			{
				//print("Moving left");
				player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
			}

		}
		//*********Mukai's code********//

		trigger = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger);
		triggerButtonPressed = controller.GetPress(triggerButton);

		if (triggerButtonPressed) {
            //print("Moving");
            player.transform.position -= player.transform.forward * Time.deltaTime * (playerSpeed);

			playerPos = player.transform.position;
			playerPos.y = Terrain.activeTerrain.SampleHeight(player.transform.position);
			player.transform.position = playerPos;
		}

		bool menuButtonPressed = controller.GetPress (menuButton);

		if (menuButtonPressed) {
			SceneManager.LoadScene("Menu 3D");
		}
	}
}