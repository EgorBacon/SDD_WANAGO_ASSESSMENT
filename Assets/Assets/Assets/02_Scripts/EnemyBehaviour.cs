using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float LookRadius = 20f;
    public float MoveSpeed = 2f;
    public Transform spawnPoint;
    Transform target;


    private void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

    }

    private void OnCollisionEnter (Collider coll)
    {
        Debug.Log("hit somin " + coll.name);
        if(coll.tag == "Lazer") {
            gameObject.transform.position = spawnPoint.transform.position;
        }           
    }

}
