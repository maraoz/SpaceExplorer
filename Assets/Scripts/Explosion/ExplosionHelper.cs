using UnityEngine;
using System.Collections;

public class ExplosionHelper : MonoBehaviour {

	public static ExplosionHelper Instance;

  public ParticleSystem fireEffect;
  public ParticleSystem smokeEffect;

	void Awake () {
		if (Instance != null) {
			Debug.LogError("Multiple instances of ExplotionHelper!");
		}

		Instance = this;
	}
	
	public void Explosion(Vector3 position) {
		instantiate(fireEffect, position);
		instantiate(smokeEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position) {
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
		) as ParticleSystem;

		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);

		return newParticleSystem;
	}
}
