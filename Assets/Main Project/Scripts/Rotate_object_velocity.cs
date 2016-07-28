using UnityEngine;
using System.Collections;

public class Rotate_object_velocity : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Transform tsfm;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		tsfm = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		//*
		float getAngle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg;
		tsfm.rotation = Quaternion.Euler(0.0f,0.0f,getAngle);
		//*/

		//tsfm.rotation = Quaternion.LookRotation(rb2d.velocity);
	}
}
