﻿using UnityEngine;
using System.Collections;

public class Steer_Flee : MonoBehaviour {

	public float maxSpeed = 100.0f;
	[Range(0,1)]
	public float steerScale = 1.0f;
	public Transform target;
	
	//private float speed = 0;
	
	
	private Rigidbody2D rb2d;
	private Transform tsfm;
	
	
	// Private variables to keep track of the variables
	
	Vector2 targetDirection;
	Vector2 desiredVelocity;
	Vector2 steeringVelocity;
	
	
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
	
	void steerVelocity(){
		
		
		targetDirection = (Vector2)(tsfm.position - target.position);
		desiredVelocity = targetDirection.normalized * maxSpeed;
		steeringVelocity = desiredVelocity - rb2d.velocity;
		steeringVelocity = Vector2.ClampMagnitude(steeringVelocity, maxSpeed);
		
		rb2d.velocity = Vector2.ClampMagnitude((rb2d.velocity + (steeringVelocity * steerScale)), maxSpeed);
		
	}
}
