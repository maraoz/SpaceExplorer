using UnityEngine;
using System.Collections;

// Asumes it is correctly binded to parent
public class CelestialBody : MonoBehaviour 
{
	public Transform body;

	private Vector3 orbitAxis;
	private float orbitSize;
	private float orbitalVelocity;

	private Transform trans;

	public void Awake()
	{
		this.trans = this.transform;
	}

	public void Initialize(CelestialBody parentBody, Vector3 orbitAxis, float orbitSize,
	                       float scale, float orbitalVelocity)
	{
		if (parentBody)
			TransformUtils.Bind (this.trans, parentBody.trans, true);

		body.localScale = Vector3.one * scale;

		this.orbitSize = orbitSize;
		this.orbitAxis = orbitAxis;
		this.orbitalVelocity = orbitalVelocity;
	}

	public void Update () 
	{
		float t = Time.time * orbitalVelocity / orbitSize;
		this.trans.localPosition = Quaternion.Euler(orbitAxis) * new Vector3(Mathf.Cos(t), Mathf.Sin(t), 0f) * orbitSize;	
	}
}