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
    public bool Pause = false;
    //public float MainPower = 10.0f;
    //public float MainFireRate = 15f;
    //public float BlockPower = 10.0f;
    //public float BlockFireRate = 15f;
   //public float PowerUpPower = 10.0f;
   // public float PowerUpFireRate = 15f;
    //public float spreadAngleMain;
    //private float nextTimeToFire = 0f;
    public Vector2 Limit;
    public Transform Player;
    public Transform CameraCentrePoint;
    public Transform BulletSpawn;
    public Camera kamera;
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

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = kamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        Vector3 CameraPosition = transform.position;

        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 lookAt = cameraRay.GetPoint(rayLength);
            Player.transform.LookAt(new Vector3(lookAt.x, Player.transform.position.y, lookAt.z));
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - Border)
        {
            CameraPosition.z += CameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y >= Screen.height - Border)
        {
            CameraPosition.z -= CameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.y >= Screen.height - Border)
        {
            CameraPosition.x += CameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.y >= Screen.height - Border)
        {
            CameraPosition.x -= CameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("f"))
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
        }
        else
        {
            Time.timeScale = 1;
        }

       


        CameraPosition.x = Mathf.Clamp(CameraPosition.x, -Limit.x, Limit.x);
        CameraPosition.y = Mathf.Clamp(CameraPosition.y, minY, maxY);
        CameraPosition.z = Mathf.Clamp(CameraPosition.z, -Limit.y, Limit.y);

        float scrollMouse = Input.GetAxis("Mouse ScrollWheel");

        CameraPosition.y += -scrollMouse * zoomSpeed * 1000f * Time.deltaTime;

        transform.position = CameraPosition;
    }

   

    
}

