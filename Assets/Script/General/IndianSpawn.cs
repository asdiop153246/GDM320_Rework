using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianSpawn : MonoBehaviour
{
    public GameObject Unit;
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiate(Unit, gameObject.transform.position,gameObject.transform.rotation);
        }
    }

    
}
