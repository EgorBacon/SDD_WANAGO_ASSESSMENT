using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float LookRadius = 20f;
    public float MoveSpeed = 2f;
    public Transform spawnPoint;
    public Transform target;



    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= LookRadius)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.LookAt(spawnPoint);
        }

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch");
        if (other.gameObject.tag == "Lazer")
        {
            transform.position = spawnPoint.position;
        }
    }
}
