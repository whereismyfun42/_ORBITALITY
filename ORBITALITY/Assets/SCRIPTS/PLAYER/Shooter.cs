using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

    public static Shooter instance;

	// Reference to projectile prefab to shoot
	public GameObject projectile;
    public GameObject projectile2;
    public GameObject projectile3;
    public List<GameObject> Rockets = new List<GameObject>();
    public float power = 10.0f;
    public float MainFireRate = 15f;
    public float power2 = 10.0f;
    public float power3 = 10.0f;

    private float nextTimeToFire = 0f;


    // Reference to AudioClip to play
    public AudioClip shootSFX;
    public AudioClip shootSFX2;
    public AudioClip shootSFX3;

    // Update is called once per frame
    void Update()
    {
        // Detect if fire button is pressed
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {

            nextTimeToFire = Time.time + 1f / MainFireRate;
            // if projectile is specified
            if (projectile)
            {
                // Instantiante projectile at the camera + 1 meter forward with camera rotation
                GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;
               // RocketAttract.instance.Rockets.Add(newProjectile);
                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

                // play sound effect if set
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                    }
                }
            }
        }

        /*foreach (GameObject rocket in Rockets)
        {
            Vector3 difference = other.transform.position - this.transform.position;

            float dist = difference.magnitude;
            Vector3 gravityDirection = difference.normalized;
            float gravity = 6.7f * (this.transform.localScale.x * this.transform.localScale.x * 1) / (dist * dist);
            Vector3 gravityVector = (gravityDirection * gravity);
            this.transform.GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Acceleration);
        }*/

        if (Input.GetButtonDown("Fire2"))
        {
            // if projectile is specified
            if (projectile)
            {
                // Instantiante projectile at the camera + 1 meter forward with camera rotation
                GameObject newProjectile = Instantiate(projectile2, transform.position + transform.forward, transform.rotation) as GameObject;

                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power2, ForceMode.VelocityChange);

                // play sound effect if set
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX2);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX2, newProjectile.transform.position);
                    }
                }
            }


        }
        if (Input.GetMouseButtonDown(2))
        {
            // if projectile is specified
            if (projectile)
            {
                // Instantiante projectile at the camera + 1 meter forward with camera rotation
                GameObject newProjectile = Instantiate(projectile3, transform.position + transform.forward, transform.rotation) as GameObject;

                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power3, ForceMode.VelocityChange);

                // play sound effect if set
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX3);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX3, newProjectile.transform.position);
                    }
                }
            }

        }
    }
}
