using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour 
{
	public float speed = 0.2f;
	public float destroyAt = -150f;
	public GameObject Cloud;
	GameObject cl;
	public bool shrink = false;
	public float shrinkage = 0.8f;
	////////////
	moveclouds mc;
	float rnd = 0f;
	Vector3 v = Vector3.zero;
	// Use this for initialization
	public void Spawn() 
	{
		//calculate random height
		rnd = Random.Range(-10f,10f);
		//Debug.Log(rnd);
		v = new Vector3(transform.position.x,transform.position.y+rnd,transform.position.z);
		//spawn cloud object
		//
		cl = Instantiate(Cloud, v, transform.rotation) as GameObject;
		//////////////////////
		mc= cl.GetComponent<moveclouds>();
		cl.transform.parent = transform;
		mc.cs = this;
		mc.speed = speed;
		mc.destroyAt = destroyAt;
		if(shrink)
		{
			cl.transform.localScale = new Vector3(shrinkage,shrinkage,shrinkage);
		}
		/////////////////////
		
	}
	
	
}
