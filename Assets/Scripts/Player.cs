using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed;

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (horizontal, 0f, vertical);
		movement = Camera.main.transform.TransformDirection (movement);
		//movement.y = 0;

		transform.position += movement * speed;
	}
}