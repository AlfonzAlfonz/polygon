using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	// Use this for initialization
	Camera cam;
	void Start () { 
		Camera cam = GetComponent<Camera> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt (cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane)), Vector3.up);
	}
}