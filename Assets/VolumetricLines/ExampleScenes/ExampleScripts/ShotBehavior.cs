using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class ShotBehavior : MonoBehaviour 
	{    
		public float speed = 20f;
		//GameObject player;     

		// Use this for initialization
		void Start () 
		{
			//player = GameObject.FindGameObjectWithTag ("Player");
		}
		
		// Update is called once per frame
		void Update () 
		{

			transform.position += transform.forward * Time.deltaTime * speed;
		}

		void OnCollisionEnter(Collision otherObj)
		{
			if (otherObj.gameObject.tag == "Player")
				Destroy (gameObject, 1f);
		}

       
     }  
    
}