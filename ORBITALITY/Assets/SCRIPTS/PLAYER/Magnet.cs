using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public float forceFactor = 200f;

    List<Rigidbody> rgbBalls = new List<Rigidbody>();

    Transform magnetPoint;
    // Start is called before the first frame update
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Rocket"))
        {
            rgbBalls.Add(other.GetComponent<Rigidbody>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
