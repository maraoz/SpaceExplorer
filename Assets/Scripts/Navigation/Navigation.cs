using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Navigation : MonoBehaviour 
{
	public float maxAcceleration = 5f;
	public float maxVelocity = 30f;

	private Transform trans;
	private Rigidbody rBody;

	private float currentAcceleration = 0f;

	public float Acceleration
	{
		get { return currentAcceleration; }
		set 
		{
			currentAcceleration = Mathf.Clamp(value, -maxAcceleration, maxAcceleration);
		}
	}

	public void Orient(float up, float right)
	{
		this.transform.forward = this.trans.forward + this.trans.up * up + this.trans.right * right;
	}

	public void Awake () 
	{
		this.trans = this.transform;
		this.rBody = this.rigidbody;
		this.rBody.useGravity = false;
	}

	public void FixedUpdate () 
	{
		rBody.AddForce (currentAcceleration * trans.forward);
	}
}