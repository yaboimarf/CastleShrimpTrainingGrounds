using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform spawnposition;
    public float arrowspeed;

    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject arrow = Instantiate(arrowPrefab, spawnposition.position, Quaternion.identity, GameObject.FindGameObjectWithTag("ArrowHolder").transform);
            arrow.GetComponent<Rigidbody>().AddForce(spawnposition.forward * arrowspeed, ForceMode.Impulse);

            Debug.Log("ik spawn");
        }
    }
}
