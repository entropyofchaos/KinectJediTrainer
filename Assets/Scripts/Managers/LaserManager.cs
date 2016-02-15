using UnityEngine;

namespace CompleteProject
{
	public class LaserManager : MonoBehaviour
	{
		public PlayerHealth playerHealth;       // Reference to the player's heatlh.
		public GameObject shotPrefab;                // The enemy prefab to be spawned.
		public Transform player;
		public Transform spawnPoints;

		//public float spawnTime = 3;


		void Start ()
		{
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            Vector3 dist = player.position - transform.position;
            if (dist.magnitude < 100)
            {
                InvokeRepeating("Spawn", Random.Range(1.0F, 3.0F), Random.Range(1.0F, 3.0F));
            }
			//SetRandomTime ();
		}
			

		void Spawn ()
		{
            // If the player has no health left...
            

            if (playerHealth.currentHealth <= 0f )
			{
				// ... exit the function.
				return;
			}
				
			GameObject shotObject = (GameObject)Instantiate(shotPrefab, spawnPoints.position, Quaternion.LookRotation((player.position - spawnPoints.position)));
            Rigidbody shot = shotObject.GetComponent<Rigidbody>();
		}
	}
}