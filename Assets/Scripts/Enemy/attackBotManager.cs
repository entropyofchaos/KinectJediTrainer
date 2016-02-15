using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class attackBotManager : MonoBehaviour
	{
		public PlayerHealth playerHealth;       // Reference to the player's heatlh.
		public GameObject enemy;                // The enemy prefab to be spawned.
		public Transform[] spawnPoints;
		public float spawnTime = 3f;


		void Start ()
		{
			// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
			InvokeRepeating ("Spawn", spawnTime, spawnTime);
		}


		void Spawn ()
		{
			// If the player has no health left...
			if(playerHealth.currentHealth <= 0f)
			{
				// ... exit the function.
				return;
			}

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}
	}
}