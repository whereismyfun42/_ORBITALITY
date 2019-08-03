using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRocket : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            StartCoroutine("Destr");
        }
    }

    public IEnumerator Destr()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
