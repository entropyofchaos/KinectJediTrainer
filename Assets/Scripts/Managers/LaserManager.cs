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
			InvokeRepeating ("Spawn", Random.Range(1.0F,1.5F), Random.Range(1.0F,1.5F));
			//SetRandomTime ();
		}
			

		void Spawn ()
		{
			// If the player has no health left...
			if(playerHealth.currentHealth <= 0f)
			{
				// ... exit the function.
				return;
			}
				
			GameObject shotObject = (GameObject)Instantiate(shotPrefab, spawnPoints.position, Quaternion.LookRotation((player.position - spawnPoints.position)));
            Rigidbody shot = shotObject.GetComponent<Rigidbody>();

			//var angle = player.position - spawnPoints.position;
			//shot.GetComponent<Rigidbody> ().AddForce (angle * shotSpeed);
		}
		/*void SetRandomTime(){
			spawnTime = Random.Range (minTime, maxTime);
		}*/
	}
}