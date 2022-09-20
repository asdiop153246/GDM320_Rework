using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIPloadscene : MonoBehaviour
{
   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("warp"))
        {
            transform.position = new Vector2 (16.61f,-2.24f);
        }
    }
  
}
