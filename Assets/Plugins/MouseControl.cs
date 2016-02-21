using UnityEngine;
using System.Collections;
//rotates an object based on mouse input
public class MouseControl : MonoBehaviour {

	public float speed = 5;
	public bool invertX = false;
	public bool invertY = false;
	
	float yDeg;
	float xDeg;
	Quaternion fromRotation;
	Quaternion toRotation;
	// Update is called once per frame
	void Update () 
	{ 
		if(Input.GetKeyDown(KeyCode.X))
		{
			invertX = !invertX;
		}
		if(Input.GetKeyDown(KeyCode.Y))
		{
			invertY = !invertY;
		}
		if(Input.GetMouseButton(0)) 
		{
			
			
			if(invertX)
			{
				xDeg += Input.GetAxis("Mouse X") * speed * speed;
			}
			else
			{
				xDeg -= Input.GetAxis("Mouse X") * speed * speed;
			}
			xDeg = ClampAngle(xDeg, -70, 70);
			if(invertY)
			{
				yDeg -= Input.GetAxis("Mouse Y") * speed * speed;
			}
			else
			{
				yDeg += Input.GetAxis("Mouse Y") * speed * speed;
			}
			yDeg = ClampAngle(yDeg, -100, -10);
			//Debug.Log(yDeg);
			fromRotation = transform.rotation;
			toRotation = Quaternion.Euler(yDeg,xDeg,0);
			transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime  * speed);
		}
	}
	public float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
		angle += 360F;
		if (angle > 360F)
		angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
	
}
