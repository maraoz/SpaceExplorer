using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Asumes it is correctly binded to parent
public class CelestialBody : MonoBehaviour 
{
	public Transform body;

	private Vector3 orbitAxis;
	private float orbitSize;
	private float orbitalVelocity;

	private Transform trans;
	private Vector3 bodyAxis;

	public List<GameObject> gravityObjects;

	public void Awake()
	{
		this.trans = this.transform;

		gravityObjects = new List<GameObject> ();
	}

	public void Initialize(CelestialBody parentBody, Vector3 orbitAxis, float orbitSize,
	                       float scale, float orbitalVelocity)
	{
		if (parentBody)
			TransformUtils.Bind (this.trans, parentBody.trans, true);

		bodyAxis = Random.onUnitSphere;

		body.localScale = Vector3.one * scale;
		body.localRotation = Random.rotation;

		this.orbitSize = orbitSize;
		this.orbitAxis = orbitAxis;
		this.orbitalVelocity = orbitalVelocity;
	}

	public void SetMass(float mass)
	{
		rigidbody.mass = mass;
	}

	public void AddGravityObject(GameObject go)
	{
		gravityObjects.Add (go);
	}

	public void Update () 
	{
		float t = Time.time * orbitalVelocity / orbitSize;
		this.trans.localPosition = Quaternion.Euler(orbitAxis) * new Vector3(Mathf.Cos(t), Mathf.Sin(t), 0f) * orbitSize;	
		body.localRotation *= Quaternion.Euler(bodyAxis);
	}

	void FixedUpdate()
	{
		foreach (GameObject go in gravityObjects) {
			Vector3 myPos = rigidbody.position;
			Vector3 goPos = go.rigidbody.position;
			float myMass = rigidbody.mass;
			float goMass = go.rigidbody.mass;
			
			Vector3 direction = Vector3.Normalize(goPos - myPos);
			float distance = Vector3.Distance(goPos, myPos);
			
			Vector3 force = - direction * myMass * goMass / (distance*distance);
			go.rigidbody.AddForce(force);
		}
		
	}
}