using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
public class PlayerHealing : MonoBehaviour {

	PlayerHealth playerhealth;
	int currenthealth;
	public ParticleSystem healingParticle;
	public Slider healthSlider; 


	// Use this for initialization
	void Start () {
		currenthealth = playerhealth.currentHealth;
		healingParticle = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			healingParticle.Stop ();
			healingParticle.Play ();
			currenthealth = playerhealth.startingHealth;
			healthSlider.value = currenthealth;
		}
	}
 }
}