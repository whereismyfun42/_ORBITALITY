using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    //public Transform ChildToBe;
    public float speed = 10f;
    public GameObject currentHitobject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask = 0;

    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;
    

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal)){
            currentHitobject = hit.transform.gameObject;
            if (currentHitobject.CompareTag("Planet"))
            {
                this.transform.RotateAround(currentHitobject.transform.position, currentHitobject.transform.up, speed * Time.deltaTime);
                StartCoroutine("Destr");
            }
        }
    }

    /*void OnTriggerEnter(Collider other)
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        //ChildToBe.transform.SetParent(other.transform);
        
        //other.gameObject.GetComponent<Planet>().Attract(ChildToBe);
        if (other.gameObject.CompareTag("Planet1"))
        {
            //this.gameObject.transform.SetParent(other.transform);
            //this.gameObject.transform.localScale += new Vector3(5, 5, 5);
            //this.gameObject.AddComponent<FixedJoint>();
            //other.gameObject.AddComponent<Rigidbody>();
           // this.gameObject.GetComponent<FixedJoint>().connectedBody = other.gameObject.GetComponent<Rigidbody>();
            this.transform.RotateAround(other.transform.position, other.transform.up, speed * Time.deltaTime);
            //this.gameObject.GetComponent<SpringJoint>().spring = 1f;
            StartCoroutine("Destr");
        }*/
        
        //Destroy(other.gameObject);
    

    public IEnumerator Destr()
    {
        yield return new WaitForSeconds(2);
        Destroy(currentHitobject);
    }
    public void OnDestroy()
    {
        ScoreController.instance.Score++;
    }

}
