using UnityEngine;
using System.Collections;

public class SolarSystemFactory : MonoBehaviour 
{
	public float maxOrbitalVelocity = 10f;

	public CelestialBody planetPrefab;
	public CelestialBody sunPrefab;



	public void Start()
	{
		CelestialBody sun = GameObject.Instantiate (sunPrefab) as CelestialBody;

		sun.Initialize (null, Random.onUnitSphere, Random.value * 50f, Random.value * 100f + 100f, 1f);

		for(int i = 0; i < 10; i++)
		{
			CelestialBody body = GameObject.Instantiate(planetPrefab) as CelestialBody;
			body.Initialize(sun, Random.onUnitSphere * 90f, Random.value * 250f + 200f, Random.value * 20f + 5f, Random.value * maxOrbitalVelocity);
		
			for(int j = 0; j < 5; j++)
			{
				CelestialBody moon = GameObject.Instantiate(planetPrefab) as CelestialBody;
				moon.Initialize(body, Random.onUnitSphere * 90f, Random.value * 25f + 20f, Random.value * 5f, Random.value * maxOrbitalVelocity * .5f);
			}
		}
	}
}