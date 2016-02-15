using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;
    private FutureGestureRecognizer futureGesture;

    // Use this for initialization
    void Start(){
        futureGesture = transform.parent.GetComponentInChildren<FutureGestureRecognizer>();
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
        Invoke("ToggleCameraOn", 3);

    }

    


    void Update() {
		if (Input.GetKeyDown (KeyCode.C) || FutureGestureTriggered()) {
			ToggleCameraOff ();
		}
        if (Input.GetKeyUp(KeyCode.C) && !FutureGestureTriggered())
        {
            ToggleCameraOn();
        }
        //Invoke("ToggleCameraOn", 5);
    }

    bool FutureGestureTriggered()
    {
        if (futureGesture == null) return false;

        return futureGesture.GestureIsTriggered();
    }
}
