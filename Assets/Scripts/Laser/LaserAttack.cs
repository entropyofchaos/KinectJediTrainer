using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class LaserAttack : MonoBehaviour 
	{

		public float timeBetweenAttacks = 1f;     // The time in seconds between each attack.
		public int attackDamage = 10;               // The amount of health taken away per attack.

        GameObject lightsaber;
        GameObject player;                          // Reference to the player GameObject.
		PlayerHealth playerHealth;                  // Reference to the player's health.
		bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
        bool LightsaberInRange;
        float timer;                                // Timer for counting up to the next attack.

		void Awake ()
		{
			// Setting up the references.
			player = GameObject.FindGameObjectWithTag ("Player");
            lightsaber = GameObject.FindGameObjectWithTag("Lightsaber");
            playerHealth = player.GetComponent <PlayerHealth> ();
		}


		void OnTriggerEnter (Collider other)
		{
			// If the entering collider is the player...
			if(other.gameObject.transform.IsChildOf(player.transform))
			{
				// ... the player is in range.
				playerInRange = true;
			}
            if (other.gameObject == lightsaber)
            {
                // ... the player is in range.
                LightsaberInRange = true;
            }
        }


		void OnTriggerExit (Collider other)
		{
			// If the exiting collider is the player...
			if(other.gameObject.transform.IsChildOf(player.transform) && other.gameObject != lightsaber.gameObject)
			{
				// ... the player is no longer in range.
				playerInRange = false;
			}
            if (other.gameObject == lightsaber)
            {
                // ... the player is no longer in range.
                LightsaberInRange = false;
            }
        }


		void Update ()
		{
			// Add the time since Update was last called to the timer.
			timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && LightsaberInRange)
            {
                // ... attack.
                Block();
            }


            // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
            if (timer >= timeBetweenAttacks && playerInRange && LightsaberInRange != true)
			{
				// ... attack.
				Attack ();
			}

			// If the player has zero or less health...
			if(playerHealth.currentHealth <= 0)
			{
				return;
			}
		}


		void Attack ()
		{
			// Reset the timer.
			timer = 0f;

			// If the player has health to lose...
			if(playerHealth.currentHealth > 0)
			{
				// ... damage the player.
				playerHealth.TakeDamage (attackDamage);
			}
		}
        void Block()
        {
            // Reset the timer.
            timer = 0f;



        }
    }
}