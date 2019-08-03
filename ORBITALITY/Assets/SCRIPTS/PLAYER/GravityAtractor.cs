using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAtractor : MonoBehaviour
{
    /*private Transform rocketTransform;
    public GameObject Explosion;
    public Rigidbody rb;
    public bool crashed = false;
    public Transform target;
    public float speed = 10f;*/

    public GameObject currentHitobject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask = 0;

    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

    /*void Start()
    {
        rocketTransform = transform;
        rb = GetComponent<Rigidbody>();
    }*/


        void Update(){
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitobject = hit.transform.gameObject;
            if (currentHitobject.CompareTag("Planet"))
            {

                Vector3 difference = this.transform.position - currentHitobject.transform.position;

                float dist = difference.magnitude;
                Vector3 gravityDirection = difference.normalized;
                float gravity = 6.7f * (this.transform.localScale.x * currentHitobject.transform.localScale.x * 1) / (dist * dist);
                Vector3 gravityVector = (gravityDirection * gravity);
                currentHitobject.transform.GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Acceleration);
                //this.transform.RotateAround(currentHitobject.transform.position, currentHitobject.transform.up, speed * Time.deltaTime);
                //StartCoroutine("Destr");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        /*other.gameObject.GetComponent<Planet>().Attract(rocketTransform);
        other.gameObject.GetComponent<SphereCollider>().enabled = false;
        other.gameObject.GetComponent<Planet>().Attract(rocketTransform);
        Vector3 direction = (Vector3)other.gameObject.transform.position - rb.position;
        direction.Normalize();
        target = other.gameObject.transform;
        crashed = true;   */
        
    }
}
