using UnityEngine;
using System.Collections;

public class FlyMoveTowardsPlayer : MonoBehaviour {

	public float maxSpeed = 5.0f;
	public float maxAcceleration = 0.5f;
	public float steerRate = 1.0f;
	public Transform player; // for now, the fly object will target towards the single player

	private Transform flyTSFM;
	private Rigidbody2D rb2d;
	private Vector3 prevVelocity;
	private float speed = 0; // Rough draft until I figure 0ut accelration
	private float acceleration = 0;


	// Use this for initialization
	void Start () {
		flyTSFM = GetComponent<Transform>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		FlyVelocity();
		RotateTowardsPlayer();

	}

	private void RotateTowardsPlayer(){
		Vector3 playerPos = player.transform.position;

		Vector3 targetDirection = playerPos - flyTSFM.transform.position;


		float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;


		//* Experiment with rotation movement

		  // This one is the ordinary behavior of object turining around in a circle
		  // Until it faces the player

		  flyTSFM.rotation = Quaternion.RotateTowards(flyTSFM.rotation,
		                              Quaternion.Euler(0,0,targetAngle), steerRate);

		//*/


		/* This one makes object turn directly towards the player

		Quaternion q = Quaternion.AngleAxis(targetAngle, Vector3.forward);
		flyTSFM.rotation = Quaternion.Slerp(flyTSFM.rotation,q,steerRate);

		 //*/

		/* Let's try an orbit-based behavior

		 //*/








	}

	private void FlyVelocity(){

		// We need to adjust the velocity by comparing the previous value;

		rb2d.velocity = flyTSFM.up * maxSpeed;  // Rough draft until I figure 0ut accelration
		prevVelocity = rb2d.velocity;

	}

	private void FlyAccelration(){

		// Conditions for positive acceleration

		/*

		if (speed < 0 && speed < maxspeed){
			speed += acceleration;
		}

		// COnditions for negative acceleration
		if ((speed < 0 && speed > -maxspeed) || (speed > 0 && speed )){
			speed -= acceleration;
		}

    */

	}
}
