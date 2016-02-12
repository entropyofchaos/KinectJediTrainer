using UnityEngine;

namespace CompleteProject
{
	public class LaserManager : MonoBehaviour
	{
		public PlayerHealth playerHealth;       // Reference to the player's heatlh.
		public GameObject shotPrefab;                // The enemy prefab to be spawned.
		public float spawnTime = 3f;            // How long between each spawn.
		public Transform player;
		public Transform spawnPoints;
		//public float shotSpeed = 1;


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
				
			Rigidbody shot = (Rigidbody)Instantiate(shotPrefab, spawnPoints.position, Quaternion.LookRotation((player.position - spawnPoints.position)));

			//var angle = player.position - spawnPoints.position;
			//shot.GetComponent<Rigidbody> ().AddForce (angle * shotSpeed);
		}
	}
}