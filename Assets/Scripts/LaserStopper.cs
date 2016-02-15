using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class LaserStopper : MonoBehaviour
    {

        GameObject player;

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.transform.IsChildOf(player.transform))
            {
                Destroy(other.gameObject);
            }
        }

        void OnTriggerExit(Collider other)
        {
        }
    }
}