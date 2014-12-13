using UnityEngine;
using System.Collections;

public class GrabScript : MonoBehaviour
{


    public Shader highlightShader;
    public float grabDistance = 100f;

    private RaycastHit hit;
    private int layerMask = ~(1 << 8);

    private GameObject target;
    private Shader originalShader;

    private DampedOscillator attractor;
    private Transform camera;


    // Use this for initialization
    void Start()
    {
        camera = Camera.main.transform;
    }



    void SelectTarget()
    {
        target.renderer.material.color *= 2;
        attractor = target.AddComponent<DampedOscillator>();
    }



    void LookTarget()
    {
        originalShader = target.renderer.material.shader;
        target.renderer.material.shader = highlightShader;
    }

    void UnlookTarget()
    {
        if (target != null)
        {
            target.renderer.material.shader = originalShader;
            target = null;
        }
    }
    void UnselectTarget()
    {
        target.renderer.material.color /= 2;
        Destroy(attractor);
        attractor = null;
    }

    void Update()
    {

        Debug.DrawRay(camera.position, Camera.main.transform.forward * grabDistance, Color.cyan);
        bool hasHit = Physics.Raycast(camera.position, camera.forward, out hit, grabDistance);
        hasHit = hasHit && hit.collider.gameObject.layer == 8;
        bool spacePressed = Input.GetKeyDown(KeyCode.Space);

        if (target != null && hasHit && target != hit.collider.gameObject && attractor == null)
        {
            UnlookTarget();
        }
        else if (target == null && hasHit && !spacePressed)
        {
            target = hit.collider.gameObject;
            LookTarget();
        }
        else if (target != null && attractor != null && spacePressed)
        {
            UnselectTarget();
        }
        else if (hasHit && spacePressed && attractor == null)
        {
            SelectTarget();
        }
        else if (!hasHit && !spacePressed && attractor == null)
        {
            UnlookTarget();
        }


        if (target != null && attractor)
        {
            Vector3 handLocation = camera.position + camera.forward * 2.454569f;
            attractor.SetTarget(handLocation);
        }

    }
}
