using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRocket : MonoBehaviour
{
    //public GameObject Explosion;

   /* void Awake()
    {
        Explosion = Resources.Load<GameObject>("Assets/PREFABS/Boom");
    }*/

   /*     void Start()
    {
        GameObject Explosion = ORBIT.instance.Boom;
    }*/
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            //GetComponent<SphereCollider>().radius = GetComponent<SphereCollider>().radius / (3 * Time.deltaTime);
            /*other.gameObject.AddComponent<RotateAround>();
            other.gameObject.GetComponent<RotateAround>().target = this.gameObject.transform;
            other.gameObject.GetComponent<RotateAround>().speed = 50;*/
            StartCoroutine("Destr");
        }
    }

    public IEnumerator Destr()
    {
        yield return new WaitForSeconds(3);
        GameObject boom = Instantiate(ORBIT.instance.Boom, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        //boom.GetComponent<AudioSource>().PlayOneShot(Explosion.instance.boomSFX);
        Destroy(this.gameObject);
    }
}
