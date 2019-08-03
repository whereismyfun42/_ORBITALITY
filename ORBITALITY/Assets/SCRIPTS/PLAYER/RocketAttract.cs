using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAttract : MonoBehaviour
{
    public static RocketAttract instance;
    public GameObject[] Rockets;
    // Start is called before the first frame update

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        Rockets = GameObject.FindGameObjectsWithTag("Rocket");
        foreach (GameObject rocket in Rockets)
        {
            Vector3 difference = this.transform.position - rocket.transform.position;

            float dist = difference.magnitude;
            Vector3 gravityDirection = difference.normalized;
            float gravity = 6.7f * (this.transform.localScale.x * rocket.transform.localScale.x * 1) / (dist * dist);
            Vector3 gravityVector = (gravityDirection * gravity);
            rocket.transform.GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Acceleration);
        }
    }
}
