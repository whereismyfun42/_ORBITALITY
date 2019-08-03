using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            Destroy(other.gameObject);
        }
    }
}
