using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpMechanics : MonoBehaviour
{
	private bool canJump = false;

	private void Update() {
		if (Input.GetKey(KeyCode.Space) && canJump) {
			GetComponentInParent<PlayerMovement>().LaunchJump();
			canJump = false;
		}
	}
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer != 9) {
			canJump = true;
		}
	}
}
