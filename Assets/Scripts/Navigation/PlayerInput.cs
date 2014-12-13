using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Navigation))]
public class PlayerInput : MonoBehaviour 
{
	public float accelerationSensibility = 1f;
	public float orientSensibility = .1f;

	private Navigation nav;
	private Vector3 mousePosition;

	public void Awake()
	{
		this.nav = this.GetComponent<Navigation> ();
	}

	public void FixedUpdate () 
	{
		UpdateOrientation ();
		UpdateAcceleration ();
	}


	public void UpdateOrientation()
	{
		Vector3 deltaMouse = Input.mousePosition - mousePosition;
		mousePosition = Input.mousePosition;

		nav.Orient (Quaternion.Euler (new Vector3(deltaMouse.y, deltaMouse.x, 0f) * orientSensibility));
	}

	public void UpdateAcceleration()
	{
		if (Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.JoystickButton0))
			nav.Acceleration = accelerationSensibility;

		if (Input.GetKey (KeyCode.Z) || Input.GetKey(KeyCode.JoystickButton1))
			nav.Acceleration = -accelerationSensibility;
	}
}