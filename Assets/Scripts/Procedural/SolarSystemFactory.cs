using UnityEngine;
using System.Collections;

public class SolarSystemFactory : MonoBehaviour 
{
	public float maxOrbitalVelocity = 10f;

	public CelestialBody planetPrefab;
	public CelestialBody sunPrefab;
	public CelestialBody asteroidPrefab;

	public void Start()
	{
		CelestialBody sun = GameObject.Instantiate (sunPrefab) as CelestialBody;

		sun.Initialize (null, Random.onUnitSphere, Random.value * 50f, Random.value * 100f + 100f, 1f);

		GameObject player = GameObject.Find ("Player");

		for(int i = 0; i < 10; i++)
		{
			CelestialBody body = GameObject.Instantiate(planetPrefab) as CelestialBody;
			float Mass = Random.value * 900f + 100f;
			body.Initialize(sun, Random.onUnitSphere * 90f, Random.value * 250f + 200f, Mass/10.0f, Random.value * maxOrbitalVelocity);
			body.SetMass(Mass);
			body.AddGravityObject(player);

			for(int j = 0; j < 5; j++)
			{
				CelestialBody moon = GameObject.Instantiate(planetPrefab) as CelestialBody;
				moon.Initialize(body, Random.onUnitSphere * 90f, Random.value * 25f + 20f, Random.value * 5f, Random.value * maxOrbitalVelocity * .5f);
			}

		}

		for(int i = 0; i < 2000; i++)
		{
			CelestialBody asteroid = GameObject.Instantiate(asteroidPrefab) as CelestialBody;
			asteroid.Initialize(sun, Random.onUnitSphere * 180f, Random.value * 50f + 500f, Random.value * 10f + 1f, Random.value * maxOrbitalVelocity * .5f);
		}
	}
}