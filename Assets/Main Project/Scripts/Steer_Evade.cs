using UnityEngine;
using System.Collections;

public class Steer_Evade : MonoBehaviour {

	public float maxSpeed = 100.0f;
	[Range(0,1)]
	public float steerScale = 1.0f;
	public Transform target;
	
	//private float speed = 0;
	
	
	private Rigidbody2D rb2d;
	private Transform tsfm;
	
	
	// Private variables to keep track of the variables
	
	private Vector2 targetDirection;
	private Vector2 desiredVelocity;
	private Vector2 steeringVelocity;
	
	private Vector2 targetPositon_prev = Vector2.zero;
	private Vector2 targetVelocity; // assume it's target.position - targetPosition_prev;
	
	
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		tsfm = GetComponent<Transform>();
		rb2d.velocity = Vector2.zero;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate(){
		
		steerVelocity();
		
	}
	
	/*
	 * For testing purposes with the object moving by mouse,
	 * we will make a velocity based on positions of the last frame and current frame
	 * 
	 * For any target objects that do use Rigidbody (3d or 2d),
	 * we will use the built-in velocity instead
	 */
	
	Vector2 getFuturePosition(){
		
		targetVelocity = (Vector2)target.position - targetPositon_prev;
		targetPositon_prev = target.position;
		Vector2 futureTargetDistance = (Vector2)(target.position - tsfm.position);
		float futureSpeedRate = futureTargetDistance.magnitude / maxSpeed;
		Vector2 futurePosition = (Vector2)target.position + targetVelocity * futureSpeedRate;
		
		
		return futurePosition;
	}
	
	void steerVelocity(){
		
		
		targetDirection = (Vector2)tsfm.position - getFuturePosition();
		desiredVelocity = targetDirection.normalized * maxSpeed;
		steeringVelocity = desiredVelocity - rb2d.velocity;
		steeringVelocity = Vector2.ClampMagnitude(steeringVelocity, maxSpeed);
		
		rb2d.velocity = Vector2.ClampMagnitude((rb2d.velocity + (steeringVelocity * steerScale)), maxSpeed);
		
	}
}
