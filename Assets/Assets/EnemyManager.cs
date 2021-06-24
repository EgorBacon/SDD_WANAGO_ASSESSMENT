using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public GameObject spawnPoint;
}
