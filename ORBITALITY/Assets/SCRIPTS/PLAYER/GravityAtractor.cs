using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAtractor : MonoBehaviour
{
    private Transform rocketTransform;
    public GameObject Explosion;
    public Rigidbody rb;
    public bool crashed = false;
    public Transform target;
    public float speed = 10f;

    void Start()
    {
        rocketTransform = transform;
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        other.gameObject.GetComponent<Planet>().Attract(rocketTransform);
        other.gameObject.GetComponent<SphereCollider>().enabled = false;
        other.gameObject.GetComponent<Planet>().Attract(rocketTransform);
        Vector3 direction = (Vector3)other.gameObject.transform.position - rb.position;
        direction.Normalize();
        target = other.gameObject.transform;
        crashed = true;   
    }
}
