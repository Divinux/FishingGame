using UnityEngine;
using System.Collections;

public class CloudChooser : MonoBehaviour 
{

	public GameObject[] Clouds;
	GameObject cl;
	Quaternion q;
	int a = 0;
	float b = 0f;	
	float c = 1f;
	
	void Start() 
	{
		//choose random cloud
		a = Random.Range(0, Clouds.Length);
		q = Random.rotation;
		//instantiate it
		cl = Instantiate(Clouds[a],transform.position,q) as GameObject;
		//position it
		cl.transform.parent = transform;
		//scale it based on preset
		b = transform.localScale.x;
		cl.transform.localScale = new Vector3(	cl.transform.localScale.x*b,
		cl.transform.localScale.y*b,
		cl.transform.localScale.z*b);
		//add random scale
		c = Random.Range(0.8f,1.2f);
		b = cl.transform.localScale.x * c;
		//finally scale it
		cl.transform.localScale = new Vector3(b,b,b);
	}
}
