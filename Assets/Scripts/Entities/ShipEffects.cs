using UnityEngine;
using System.Collections;

public class ShipEffects : MonoBehaviour {

	public float velocityScale = 10.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float currentVel = rigidbody.velocity.magnitude;
		transform.Find("MainThrusterParticles").particleSystem.emissionRate = currentVel * velocityScale;
	}
}
