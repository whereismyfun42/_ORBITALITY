using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float gravity = -12f;

    public void Attract(Transform rocketTransform)
    {
        Vector3 gravityUp = (rocketTransform.position - transform.position).normalized;
        Vector3 localUp = rocketTransform.up;

        rocketTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * rocketTransform.rotation;
        rocketTransform.rotation = Quaternion.Slerp(rocketTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            Attract(other.transform);
        }
    }
}
