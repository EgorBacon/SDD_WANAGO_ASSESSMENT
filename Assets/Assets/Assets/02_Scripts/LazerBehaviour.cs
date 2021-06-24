using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBehaviour : MonoBehaviour {
	public float speed;
	public float lifeSpan;

	private float timeStamp;
	// Use this for initialization
	void Start () {
		timeStamp = Time.time + lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * speed * Time.deltaTime;	

		if (Time.time > timeStamp)
			Destroy (gameObject);
	}

	void OnCollisionEnter (Collision coll) {
		if (coll.transform.tag == "Hostile") {
			Destroy (gameObject);
			Destroy (coll.gameObject);
		}
	}
}
