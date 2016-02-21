using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//handles all actual actions like 
//throwing, reeling in etc
public class PoleControl : MonoBehaviour 
{

	
	public GameObject floater;
	public GameObject linestart;
	
	public float reelSpeed = 1f;
	public float throwStrength = 10f;
	//hide the following after debug
	public Floater fl;
	public FloaterHinge fh;
	public Rigidbody flRb;
	public MouseControl mc;
	
	public Line line;
	public ReelIn reel;
	/////
	//float doubleClickStart = 0;
	////
	public bool down = false;
	public bool up = false;
	
	public bool thrown = false;
	
	
	//distance calculation X/Z
	public float distance = 1f;
	public Vector2 pos1 = new Vector2(1,1);
	public Vector2 pos2 = new Vector2(1,1);
	public Text distText;
	Vector3 direction = Vector3.zero;
	
	public Text invertTextX;
	public Text invertTextY;
	void Start () 
	{
		//get all components
		fl = floater.GetComponent<Floater>();
		fh = floater.GetComponent<FloaterHinge>();
		flRb = floater.GetComponent<Rigidbody>();
		line = linestart.GetComponent<Line>();
		reel = GetComponent<ReelIn>();
		mc = GetComponent<MouseControl>();
		//initialize start state
		EnableHinge();
		
	}
	void EnableHinge()
	{
		fh.enabled = true;
		thrown = false;
		line.Tighten();
	}
	void DisableHinge()
	{
		fh.ResetPendulumForces();
		fh.enabled = false;
		thrown = true;
		line.Loosen();
	}
	void Update() 
	{ 
		//check for insta reel in
		if(Input.GetMouseButtonUp(2))
		{
			OnDoubleClick();
		}	
		//check for normal reel in
		//start sound and handle animation
		if(Input.GetMouseButtonDown(1) && thrown)
		{
			Reel();
		}
		//move the rigidbody
		if(Input.GetMouseButton(1) && thrown)
		{
			ReelRigid();
		}
		else if(Input.GetMouseButton(1) && !thrown)
		{
			OnDoubleClick();
			StopReel();
		}
		//stop animation and sound
		if(Input.GetMouseButtonUp(1) && thrown)
		{
			StopReel();
		}
		//check for throw
		//this actually makes the throwing behavior
		//change this to change throwing mode
		if(!mc.invertY)
		{
		if(Input.GetMouseButton(0))
		{
			if(Input.GetAxis("Mouse Y")<0)
			{
				down = true;
				up = false;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(Input.GetAxis("Mouse Y")>0)
			{
				up = true;
			}
			else
			{
				down = false;
				up = false;
			}
		}
		}
		else
		{
			if(Input.GetMouseButton(0))
		{
			if(Input.GetAxis("Mouse Y")>0)
			{
				down = true;
				up = false;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(Input.GetAxis("Mouse Y")<0)
			{
				up = true;
			}
			else
			{
				down = false;
				up = false;
			}
		}
		}
		//this one finally gives the command to throw
		//if all conditions are met
		//(the mouse was moved down and then up)
		if(up && down)
		{
			up = false;
			down = false;
			Throw();
		}
		//throw check end////////
		//calculate distance
		CalcDist();
		
		//debug mouse invert texts
		
		if(mc.invertX)
		{invertTextX.text = "X inverted";}
	else
	{invertTextX.text = "X default";}
		if(mc.invertY)
		{invertTextY.text = "Y inverted";}
	else
	{invertTextY.text = "Y default";}
		
	}
	void CalcDist()
	{
		pos1.x = linestart.transform.position.x;
		pos1.y = linestart.transform.position.z;
		pos2.x = floater.transform.position.x;
		pos2.y = floater.transform.position.z;
		
		distance = Vector2.Distance(pos2,pos1);
		distText.text = "" + distance.ToString("F1") +"m";
	}
	void OnDoubleClick()
	{
		EnableHinge();
		
	}
	//physically throws the floater rigidbody
	void Throw()
	{
		if(!thrown)
		{
		DisableHinge();
		ReelFast();
		flRb.AddForce(transform.forward * throwStrength, ForceMode.Impulse);
		}
	}
	//give command for sound and animation 
	void Reel()
	{	
	reel.Slow();
	}
	//move the rigidbody
	void ReelRigid()
	{
		direction = linestart.transform.position - floater.transform.position;
		flRb.AddRelativeForce(direction.normalized * reelSpeed, ForceMode.Force);
		if(distance <= 1f)
		{
			//retrieved
			//this is where you show the fish or whatever
			OnDoubleClick();
			StopReel();
		}
		//Debug.Log(distance);
	}
	//commands for sound and anim
	void ReelFast()
	{
		reel.Fast();
	}
	void StopReel()
	{
		reel.Stop();
	}
}
