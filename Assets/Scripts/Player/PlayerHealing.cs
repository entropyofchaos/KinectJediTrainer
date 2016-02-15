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

			healingParticle = GetComponent<ParticleSystem> ();
			playerhealth = GetComponent<PlayerHealth> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.H)) {
					healing ();
			}

			if (Input.GetKeyUp (KeyCode.H)) {
				healingParticle.loop = false;
			}
		}

		void healing(){
			healingParticle.Stop ();
			healingParticle.Play ();
			healingParticle.loop = true;
			playerhealth.currentHealth = playerhealth.startingHealth;
			healthSlider.value = playerhealth.startingHealth;
		}
	}
}