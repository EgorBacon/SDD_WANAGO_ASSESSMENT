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

    void OnCollisionEnter (Collision coll)
    {
        Debug.Log("hit somin ");
        if(coll.collider.tag == "Lazer") {
            gameObject.transform.position = spawnPoint.transform.position;
        }           
    }

}
