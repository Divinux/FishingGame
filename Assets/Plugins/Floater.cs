using UnityEngine;
using System.Collections;

//handles the buoyancy
public class Floater : MonoBehaviour 
{
	public GameObject pole;
	public float waterlvl = 0f;
	public float thrust = 1f;

	//PoleControl pc;
	Rigidbody rb;
	FloaterHinge fh;
	float f = 0f;
	int counter = 0;
	bool last = false;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
fh = GetComponent<FloaterHinge>();
//pc = pole.GetComponent<PoleControl>();
	}
	
	void FixedUpdate () 
	{
		if(transform.position.y < waterlvl)
		{
			//wait 10 frames because of glitchy pendulum
			if(counter >= 10)
			{
			fh.enabled = false;
			counter = 0;
			last = false;
			}
			else if(last)
			{
				counter++;
			}
			last = true;
			addforce();
		}
		else
		{
			rb.drag = 0.5f;
			last = false;
		}
	}
	
	void addforce()
	{
			f = waterlvl - transform.position.y;
			f *= f;
			rb.drag = rb.velocity.sqrMagnitude;
			rb.AddForce(transform.up * thrust * f);
	}
	
	
	
}
