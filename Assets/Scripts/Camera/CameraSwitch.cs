using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;


	// Use this for initialization
	void Start () {
		

	}

	void update(){
		if (Input.GetKeyDown("1"))
		{
			camera2.GetComponent<Camera>().enabled = false;
			camera1.GetComponent<Camera>().enabled = true;
		}
		if (Input.GetKeyDown("2")){
			camera1.GetComponent<Camera>().enabled = false;
			camera2.GetComponent<Camera>().enabled = true;
		}
	}
}
