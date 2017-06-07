using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float speed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public Boundary boundary;

	private float nextFire;

	public AudioSource audio;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource> ();
	}

	void Update() // before updating a frame
	{

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
	 		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		
		}

	}


	void FixedUpdate()  // called each physics steps
	{

		float moveHorizontal = Input.GetAxis ("Horizontal"); // default axis : Horizontal, vertical
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement*speed;
		rb.position = new Vector3
		(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
