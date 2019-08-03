using UnityEngine;

public class ShootingStarSpawner : MonoBehaviour {

    ObjectPool objectPooler;
    private void Start()
    {
        objectPooler = ObjectPool.Instance;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool(1, transform.position, Quaternion.identity);
    }
}
