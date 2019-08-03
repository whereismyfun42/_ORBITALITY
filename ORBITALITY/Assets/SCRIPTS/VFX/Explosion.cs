using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public static Explosion instance;
    public GameObject exp;
    //public AudioClip boomSFX;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {        
        exp.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        Destroy(exp, 3);
    }
}
