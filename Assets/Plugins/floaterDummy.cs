using UnityEngine;
using System.Collections;

public class floaterDummy : MonoBehaviour {

	public float waterlvl = 0f;
	public float thrust = 1f;
	Rigidbody rb;
	float f = 0f;
	void Start () 
	{
	rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate () 
	{
		if(transform.position.y < waterlvl)
		{
			f = waterlvl - transform.position.y;
			f *= f;
			//rb.drag = rb.velocity.sqrMagnitude;
			rb.AddForce(transform.up * thrust * f);
		}
	}
}

