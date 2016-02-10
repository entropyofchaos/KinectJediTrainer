using UnityEngine;

namespace CompleteProject
{
	public class LaserManager : MonoBehaviour
	{
		public PlayerHealth playerHealth;       // Reference to the player's heatlh.
		public GameObject shotPrefab;                // The enemy prefab to be spawned.
		public float spawnTime = 3f;            // How long between each spawn.
		//public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
		public Transform player;
		public Transform spawnPoints;

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

			// Find a random index between zero and one less than the number of spawn points.
			//int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

			//var lasershot = (Transform)Instantiate (shotPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			//lasershot.LookAt (player.position);

			//var direction = player.transform.position - spawnPoints.position;
			//var shot = (Transform)Instantiate(shotPrefab, spawnPoints.position, Quaternion.LookRotation(direction));

			Transform shot = Instantiate(shotPrefab, spawnPoints.position, Quaternion.LookRotation((player.position - spawnPoints.position))) as Transform;
		    //Transform PlayerCenter = player.transform.FindChild ("Center");

		}
	}
}