using UnityEngine;
using System.Collections;

public class GrabScript : MonoBehaviour {

    RaycastHit hit;
    int layerMask = ~(1 << 9);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            float distance = 500f;
            Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask);
            Debug.Log("test2 "+hit.distance);
        }
    
	}
}
