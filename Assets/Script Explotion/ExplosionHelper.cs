using UnityEngine;
using System.Collections;

public class ExplosionHelper : MonoBehaviour {

	public static ExplosionHelper Instance;

  public ParticleSystem effectYellow;
  public ParticleSystem effectRed;

	void Awake () {
		if (Instance != null) {
			Debug.LogError("Multiple instances of ExplotionHelper!");
		}

		Instance = this;
	}
	
	public void Explosion(Vector3 position) {
		instantiate(effectRed, position);
		instantiate(effectYellow, position);
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
