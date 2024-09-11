using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSpawner : MonoBehaviour
{

    [Tooltip("The prefab to instantiate when spawning new cans")] [SerializeField]
    private GameObject CanPrefab;

    [Tooltip("The initial speed to launch the can at")] [SerializeField]
    private float LaunchSpeed;

    [Tooltip("Possible variation in launch angle as the component of total launch speed along the spawner's x-axis")]
    [SerializeField]
    private float HorizontalLaunchVariation;
    
    public void SpawnCan()
    {
        // Create a new can
        GameObject can = Instantiate(CanPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = can.GetComponent<Rigidbody2D>();
        CanManager.Instance.AddCan(can.GetComponent<CanHit>());

        // Launch it into frame
        float variation = Random.Range(-HorizontalLaunchVariation, HorizontalLaunchVariation);
        rb.AddForce(LaunchSpeed * rb.mass * (transform.up + variation * transform.right), ForceMode2D.Impulse);
    }
}
