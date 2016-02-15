using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;


	// Use this for initialization
	void Start(){
		ToggleCameraOn();
	}

	public void ToggleCameraOn ()
	{
		camera1.gameObject.SetActive(true);
		camera2.gameObject.SetActive(false);
	}

	public void ToggleCameraOff ()
	{
		camera1.gameObject.SetActive(false);
		camera2.gameObject.SetActive(true);
	}


	void Update() {
		if (Input.GetKeyDown (KeyCode.C)) {
			ToggleCameraOff ();
		}
		if (Input.GetKeyUp (KeyCode.C)) {
			ToggleCameraOn ();
		}
			//Invoke("ToggleCameraOn", 5);
	}
}
