using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public GameObject player;
}
