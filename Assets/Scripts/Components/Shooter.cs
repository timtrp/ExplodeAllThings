using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public Transform projectileObject;
	public KeyCode fireButton = KeyCode.Space;
	public bool inheritVelocity = true;
	public float launchSpeed = 100.0f;
	public float totalLifetimeSec = 3.0f;
	public Vector3 localLaunchPos = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (projectileObject != null)
		{
			if (Input.GetKeyDown(fireButton))
			{
				SpawnAndLaunch();
			}
		}
	}
	
	void SpawnAndLaunch()
	{
		Vector3 parentVelocity = Vector3.zero;
		
		// If set, object inherits the parent velocity
		if (inheritVelocity)
		{
			if (rigidbody != null)
			{
				parentVelocity = rigidbody.velocity;
			}
			else if (transform.parent != null && transform.parent.rigidbody)
			{
				parentVelocity = transform.parent.rigidbody.velocity;
			}
		}
		
		// Instantiate the object
		Transform newTransform = GameObject.Instantiate(projectileObject, transform.TransformPoint(localLaunchPos), Quaternion.identity) as Transform;
		GameObject newBullet = newTransform.gameObject;
		
		// Set the initial velocity if it has a rigidbody
		if (newBullet.rigidbody)
		{
			newBullet.rigidbody.velocity = parentVelocity + transform.TransformDirection(new Vector3(0.0f, 0.0f, launchSpeed));
		}
		
		Projectile proj = newBullet.GetComponent<Projectile>();
		if (proj != null)
		{
			proj.totalLifetimeSec = totalLifetimeSec;
		}
	}
}
