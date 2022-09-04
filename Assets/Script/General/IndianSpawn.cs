using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianSpawn : MonoBehaviour
{
    public GameObject Indian;
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(Indian, gameObject.transform.position,gameObject.transform.rotation);
        }
    }

    
}
