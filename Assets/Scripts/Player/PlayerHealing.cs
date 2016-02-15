using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
public class PlayerHealing : MonoBehaviour {

	PlayerHealth playerhealth;
	//int currenthealth;
	public ParticleSystem healingParticle;
	public Slider healthSlider; 


	// Use this for initialization
	void Start () {
		//currenthealth = playerhealth.currentHealth;
		healingParticle = GetComponent<ParticleSystem> ();
		playerhealth = GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.H)) {
				healing ();
		}
	}
		void healing(){
			//currenthealth = playerhealth.startingHealth;
			healthSlider.value = playerhealth.startingHealth;
			playerhealth.currentHealth = playerhealth.startingHealth;
			healingParticle.Stop ();
			healingParticle.Play ();
		}
 }
}