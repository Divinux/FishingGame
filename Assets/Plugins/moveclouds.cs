using UnityEngine;
using System.Collections;

public class moveclouds : MonoBehaviour 
{
	public CloudSpawner cs;
	public float speed = 0.3f;
	public float destroyAt = -150f;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		if(transform.position.x <= destroyAt)
		{
			cs.Spawn();
			Destroy(gameObject);
		}
	}
}
