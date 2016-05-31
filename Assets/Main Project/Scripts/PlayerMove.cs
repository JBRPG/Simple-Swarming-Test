using UnityEngine;
using System.Collections;

/*
 * Let's make the player move by the mouse position 
 * 
 * 
*/

public class PlayerMove : MonoBehaviour {

	private Transform playerTSFM;


	// Use this for initialization
	void Start () {
		playerTSFM = gameObject.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

		// We are only moving the object by mouse
		// and keep same Z position to prevent sprite from disappearing
		Vector3 mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseTarget.z = playerTSFM.position.z;

		playerTSFM.position = mouseTarget;
	}
}
