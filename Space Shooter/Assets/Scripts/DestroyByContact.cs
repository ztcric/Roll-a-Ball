using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public int scoreValue;
	public GameObject playerExplosion;
	private GameController gameController; 



	void Start()
	{
		GameObject gameContrllerObject = GameObject.FindWithTag("GameController");
		if (gameContrllerObject != null) 
		{
			gameController = gameContrllerObject.GetComponent<GameController> ();
		}

		if (gameContrllerObject == null) 
		{
			Debug.Log ("Cannot find 'GameController' script");
		}


	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") 
		{
			return;
		}
			
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") 
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();

		}
		gameController.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
