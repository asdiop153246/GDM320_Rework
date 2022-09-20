using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPCescort : MonoBehaviour
{
    public AIPath aipath;
    
    void Update()
    {
        checkFlip();
    }

    private void checkFlip()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            return;
        }
        if (aipath.transform.localScale.x <= -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            return;
        }
    }
    
}
