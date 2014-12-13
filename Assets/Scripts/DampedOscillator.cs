using UnityEngine;
using System.Collections;

public class DampedOscillator : MonoBehaviour
{

    public GameObject targetObject;
    public float kFactor = 36f;
    public float cFactor = 8f;

    private Vector3 target;


    void Update()
    {
        if (targetObject)
        {
            target = targetObject.transform.position;
        }

        // http://hyperphysics.phy-astr.gsu.edu/hbase/oscda2.html#c1
        Vector3 bounceForce = kFactor * (target - transform.position);
        rigidbody.AddForce(bounceForce);

        Vector3 dampForce = -rigidbody.velocity * cFactor;
        rigidbody.AddForce(dampForce);

    }

    internal void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
    }
}
