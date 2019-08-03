using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject exp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exp.transform.localScale += new Vector3(1, 1, 1);
        Destroy(exp, 5);
    }
}
