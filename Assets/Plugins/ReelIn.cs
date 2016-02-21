using UnityEngine;
using System.Collections;
//rotates the handle
//plays sounds
public class ReelIn : MonoBehaviour {
public GameObject Handle;

	public float speed = 333f;
	public float speedout = 777f;
	public AudioSource audios;
	public AudioClip slow;
	public AudioClip fast;
	void Awake()
	{
		audios = GetComponent<AudioSource>();
	}
	void Update()
	{
		if(Input.GetMouseButton(1))
	{
		Handle.transform.Rotate(Vector3.right * Time.deltaTime * speed);
	}
	}
	public void Slow() 
	{
		 
		 audios.clip = slow;
		 audios.Play();
	 }
	 // throw
	 public void Fast() 
	{	
	//play fast sound
	audios.clip = fast;
		 audios.Play();
		 //start rotating the handle
		 StartCoroutine(ff());
		 //stop rotating in 1s
		 Invoke("stopFF", 1);
	 }
	 IEnumerator ff()
	 {
		 while(true)
		 {
		 Handle.transform.Rotate(-Vector3.right * Time.deltaTime * speedout);
		 yield return null;
		 }
	 }
	 //stop rotating
	 void stopFF()
	 {
		 StopAllCoroutines();
		 if(audios.clip != slow)
		 {
		 Stop();
		 }
	 }
	 //stops all sounds
	 public void Stop() 
	{
		 //Handle.transform.Rotate(Vector3.right * Time.deltaTime * speed);
		 //audios.clip = slow;
		 audios.Stop();
	 }
}
