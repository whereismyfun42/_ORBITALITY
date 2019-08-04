using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public static CameraControll instance;


    public float CameraSpeed = 20f;
    public float Border = 10f;
    public float zoomSpeed = 5f;
    public float minY = 20f;
    public float maxY = 100f;
    public float height = 25;
    public float gravity = -18;
    private float nextTimeToFireRocket = 0f;
    private float nextTimeToFireAddForceProjectile = 0f;
    private float nextTimeToFireTrackProjectile = 0f;

    public bool Pause = false;
    public GameObject PauseExit;
    public Rigidbody Rocket;
    public GameObject AddForceProjectile;
    public GameObject TrackProjectile;
    public GameObject cursor;
    public AudioClip RocketSFX;
    //public LayerMask layer;
    private Camera cam;
    //public float MainPower = 10.0f;
    public float RocketFireRate = 15f;
    public float AddForceProjectilePower = 10.0f;
    public float AddForceProjectileFireRate = 15f;
    //public float PowerUpPower = 10.0f;
    // public float PowerUpFireRate = 15f;
    //public float spreadAngleMain;
    //private float nextTimeToFire = 0f;
    public Vector2 Limit;
    public Transform Player;
    public Transform CameraCentrePoint;
    public Transform RocketSpawn;
    public Transform AddForceProjectileSpawn;
    public Transform target;
    //public GameObject MainProjectile;
    //public GameObject BlockProjectile;
    //public GameObject PowerUpProjectile;

    //public AudioClip MainShootSFX;
    //public AudioClip BlockShootSFX;
    //public AudioClip PowerUpShootSFX;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        Vector3 CameraPosition = transform.position;
        RaycastHit hit;



        /*if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;
        }*/

        if (ground.Raycast(camRay, out rayLength) && Pause == false)
        {
            Vector3 lookAt = camRay.GetPoint(rayLength);
            cursor.SetActive(true);
            cursor.transform.position = camRay.GetPoint(rayLength) + Vector3.up * 0.1f;
            Player.transform.LookAt(new Vector3(lookAt.x, Player.transform.position.y, lookAt.z));

            Vector3 Vo = CalculateVelocity(camRay.GetPoint(rayLength), RocketSpawn.position, 1.5f);

            RocketSpawn.rotation = Quaternion.LookRotation(Vo);

            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFireRocket && Pause == false)
            {
                nextTimeToFireRocket = Time.time + 1f / RocketFireRate;
                Rigidbody obj = Instantiate(Rocket, RocketSpawn.position, RocketSpawn.rotation);
                obj.velocity = Vo;
                obj.GetComponent<AudioSource>().PlayOneShot(RocketSFX);
            }


        }
        else
        {
            cursor.SetActive(true);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            AddForceProjectilePower += Time.deltaTime;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            nextTimeToFireAddForceProjectile = Time.time + AddForceProjectileFireRate;
            GameObject obj2 = Instantiate(AddForceProjectile, AddForceProjectileSpawn.position, AddForceProjectileSpawn.rotation) as GameObject;
            obj2.GetComponent<Rigidbody>().AddForce(transform.up * AddForceProjectilePower);
        }
        if (Input.GetMouseButtonDown(2))
        {
            Vector3 lookAt = camRay.GetPoint(rayLength);
            if (Physics.Raycast(lookAt, Vector3.down, out hit))
            {
                var selection = hit.transform;
                if (selection.gameObject.CompareTag("Planet"))
                {
                    target = selection;
                    GameObject obj3 = Instantiate(TrackProjectile, RocketSpawn.position, RocketSpawn.rotation) as GameObject;
                    obj3.GetComponent<Rigidbody>().velocity = CalculateTrackVelocity();
                }
            }
        }
            if ((Input.GetKey("w") || Input.mousePosition.y >= Screen.height - Border) && Pause == false)
            {
                CameraPosition.z += CameraSpeed * Time.deltaTime;
            }
            if ((Input.GetKey("s") || Input.mousePosition.y >= Screen.height - Border) && Pause == false)
            {
                CameraPosition.z -= CameraSpeed * Time.deltaTime;
            }
            if ((Input.GetKey("d") || Input.mousePosition.y >= Screen.height - Border) && Pause == false)
            {
                CameraPosition.x += CameraSpeed * Time.deltaTime;
            }
            if ((Input.GetKey("a") || Input.mousePosition.y >= Screen.height - Border) && Pause == false)
            {
                CameraPosition.x -= CameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey("f") && Pause == false)
            {
                CameraPosition.x = CameraCentrePoint.position.x;
                CameraPosition.y = CameraCentrePoint.position.y;
                CameraPosition.z = CameraCentrePoint.position.z;
                /*Vector3 teleportToPlayer = kamera.transform.position - transform.position;
                float dotProduct = Vector3.Dot(transform.up, teleportToPlayer);

                if (dotProduct < 0f)
                {
                    float rotationDiff = -Quaternion.Angle(transform.rotation, CameraCentrePoint.rotation);
                    rotationDiff += 180;
                    kamera.transform.Rotate(Vector3.up, rotationDiff);

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * teleportToPlayer;
                    kamera.transform.position = CameraCentrePoint.position + positionOffset;

                }*/
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause = !Pause;
            }

            if (Pause)
            {
                Time.timeScale = 0;
                PauseExit.SetActive(true);
                if (Input.GetKey(KeyCode.Y))
                {
                    Application.Quit();
                }

                if (Input.GetKey(KeyCode.N))
                {
                    Pause = !Pause;
                    Time.timeScale = 1;
                    PauseExit.SetActive(false);
                }
            }
            else
            {
                Time.timeScale = 1;
                PauseExit.SetActive(false);
            }




            CameraPosition.x = Mathf.Clamp(CameraPosition.x, -Limit.x, Limit.x);
            CameraPosition.y = Mathf.Clamp(CameraPosition.y, minY, maxY);
            CameraPosition.z = Mathf.Clamp(CameraPosition.z, -Limit.y, Limit.y);

            float scrollMouse = Input.GetAxis("Mouse ScrollWheel");

            CameraPosition.y += -scrollMouse * zoomSpeed * 1000f * Time.deltaTime;

            transform.position = CameraPosition;
     }

        Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
        {
            Vector3 distance = target - origin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0f;

            float Sy = distance.y;
            float Sxz = distanceXZ.magnitude;

            float Vxz = Sxz / time;
            float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            Vector3 result = distanceXZ.normalized;
            result *= Vxz;
            result.y = Vy;

            return result;
        }

        Vector3 CalculateTrackVelocity()
        {
            float displacementY = target.position.y - TrackProjectile.transform.position.y;
            Vector3 displacementXZ = new Vector3(target.position.x - TrackProjectile.transform.position.x, 0, target.position.z - TrackProjectile.transform.position.z);

            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * height);
            Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity));

            return velocityXZ + velocityY;
        }

        /*void LaunchTrackProjectile()
        {
            Physics.gravity = Vector3.up * gravity;
            TrackProjectile.GetComponent<Rigidbody>().useGravity = true;
            TrackProjectile.GetComponent<Rigidbody>().velocity = CalculateTrackVelocity();
        }*/

        /*void Shoot()
        {
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(camRay, out hit, 100f, layer))
            {
                cursor.SetActive(true);
                cursor.transform.position = hit.point + Vector3.up * 0.1f;
            }
        }*/




    
}

