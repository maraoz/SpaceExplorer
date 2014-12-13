using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public float movementSpeed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
	}

	void OnCollisionEnter() {
		ExplosionHelper.Instance.Explosion(transform.position);
		Destroy(gameObject);
	}
}
