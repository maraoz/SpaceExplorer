using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Navigation : MonoBehaviour 
{
	public float damping = .01f;
	public float maxAcceleration = 5f;
	public float maxVelocity = 30f;

	private Transform trans;
	private Rigidbody rBody;

	private float currentVelocity = 0f;
	private float currentAcceleration = 0f;

	public float Acceleration
	{
		get { return currentAcceleration; }
		set 
		{
			currentAcceleration = Mathf.Clamp(value, -maxAcceleration, maxAcceleration);
		}
	}

	public void Orient(Quaternion delta)
	{
		this.transform.forward = delta * this.trans.forward;
	}

	public void Awake () 
	{
		this.trans = this.transform;
		this.rBody = this.rigidbody;
		this.rBody.isKinematic = true;
	}

	public void FixedUpdate () 
	{
		// Eueler + damping
		this.currentVelocity += currentAcceleration * Time.fixedDeltaTime;
		this.currentVelocity *= Mathf.Clamp01(1f - damping);

		this.trans.position += trans.forward * currentVelocity * Time.fixedDeltaTime;
	}
}