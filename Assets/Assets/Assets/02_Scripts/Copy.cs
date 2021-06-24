using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy : MonoBehaviour {
	public float rotForce;
	private float rotationValueY;
	private float rotationValueX;
	public GameObject lazerObj;

	// Use this for initialization
	void Start () {
		rotationValueY = transform.rotation.y;
		rotationValueX = transform.rotation.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (rotationValueX, rotationValueY, 0);

		if (Input.GetKey (KeyCode.A)) {
			rotationValueY -= rotForce * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {
			rotationValueY += rotForce * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W)) {
			rotationValueX -= rotForce * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			rotationValueX += rotForce * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Instantiate (lazerObj, transform.position, transform.rotation);
		}
	}
}
