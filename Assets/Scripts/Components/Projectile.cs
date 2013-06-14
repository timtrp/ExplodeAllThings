using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float totalLifetimeSec = 3.0f;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, totalLifetimeSec);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
}
