using UnityEngine;
using System.Collections;

/*
 * With the wander behavior, we place a displacement circle ahead of the steering object
 * and then have a wandering angle so that the object behaves like a casual random movement
 * without going jittery.
*/

public class Steer_Wander : MonoBehaviour {


	public float maxSpeed = 100.0f;
	[Range(0,1)]
	public float steerScale = 1.0f;

	/*
	 * When placing a displacement circle,
	 * it has to be within the velocity vector range based on uniform magnitude
	*/
	[Range(0,1)]
	public float displacementCircleCenter; // place in front of moving chracter based on velocity's magnitude factor
	public float displacementCircleRadius; // needed to determine the displacement magnitude
	[Range(0,90)]
	public float changeAngle; // needed to make displacement vector


	
	private Rigidbody2D rb2d;
	private Transform tsfm;

	
	Vector2 targetDistance;
	Vector2 desiredVelocity;
	Vector2 steeringVelocity;

	private float distToWCCenter;
	private Vector2 distToWCCenterVector;
	private Vector2 wanderVelocity;
	private Vector2 displacementVector;

	private float wanderAngle;
	
	
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		tsfm = GetComponent<Transform>();
		rb2d.velocity = tsfm.up * maxSpeed;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate(){
		
		wander();
		
	}


	/*
	 * To actually get the 
	*/

	void wander(){

		//float velocityAngle = Mathf.Atan2(rb2d.velocity.y,rb2d.velocity.x) * Mathf.Rad2Deg;


		distToWCCenter = 1.0f - displacementCircleCenter; // assume velocity magnitude is normalized

		distToWCCenterVector = rb2d.velocity * distToWCCenter;

		// make sure that the object can steer left or right
		wanderAngle = (Random.Range(0.0f, 1.0f) * changeAngle) - (changeAngle * 0.5f);

		// set the displacement vector with the wander angle
		displacementVector = Vector2.one;
	    displacementVector.Set(Mathf.Cos(wanderAngle) * displacementCircleRadius,
		                             Mathf.Sin(wanderAngle) * displacementCircleRadius);
		Vector2 wanderVelocity = distToWCCenterVector + displacementVector;

		rb2d.velocity = Vector2.ClampMagnitude(wanderVelocity,maxSpeed);


	}
	
}