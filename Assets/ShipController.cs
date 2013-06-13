using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float thrust = 10.0f;
	public float rotateThrust = 15.0f;
	public float maxLinearVelocity = 50.0f;
	public float maxAngularVelocity = 80.0f;
	public GameObject mainEngineParticles;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		
	}
	
	void FixedUpdate() 
	{
		// Process the ship's steering
		ProcessSteering();	
		
		// Cap the velocity of the ship
		CapVelocity();
	}
	
	void ProcessSteering()
	{
		if (Input.GetKey(KeyCode.W))
		{
			rigidbody.AddForce( transform.forward * thrust );
		}
		
		if (Input.GetKey (KeyCode.A))
		{
			rigidbody.AddTorque( Vector3.up * -rotateThrust );
		}
		else if (Input.GetKey (KeyCode.D))
		{
			rigidbody.AddTorque( Vector3.up * rotateThrust );
		}
	}
	
	void CapVelocity()
	{
		
		if (rigidbody.velocity.magnitude > maxLinearVelocity)
		{
			rigidbody.velocity.Normalize();
			rigidbody.velocity *= maxLinearVelocity;
		}
		if (rigidbody.angularVelocity.magnitude > maxAngularVelocity)
		{
			rigidbody.angularVelocity.Normalize();
			rigidbody.angularVelocity *= maxAngularVelocity;
		}
	}
}
