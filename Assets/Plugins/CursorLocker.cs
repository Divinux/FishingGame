using UnityEngine;
using System.Collections;

public class CursorLocker : MonoBehaviour {

	CursorLockMode wantedMode;
	
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			wantedMode = CursorLockMode.None;
			SetCursorState();
		}
		if(Input.GetMouseButton(0)) 
		{
			wantedMode = CursorLockMode.Locked;
			SetCursorState();
		}
	}
	// Apply requested cursor state
	void SetCursorState()
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}
}
