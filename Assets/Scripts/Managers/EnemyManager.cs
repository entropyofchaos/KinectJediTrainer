﻿using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public Transform player;
      

		void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }



        void Spawn ()
		{
			// If the player has no health left...
			if (playerHealth.currentHealth <= 0f) {
				// ... exit the function.
				return;
			}

			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

			GameObject generatedEnemy = (GameObject)Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);

			LaserManager laserManager = generatedEnemy.GetComponent<LaserManager> ();
			laserManager.playerHealth = playerHealth;
			GameObject eye_enemy = generatedEnemy.gameObject.transform.GetChild (0).GetChild (0).GetChild(0).GetChild(0).GetChild(0).gameObject;
			laserManager.spawnPoints = eye_enemy.transform;
            laserManager.player = player;

        }
    }
}