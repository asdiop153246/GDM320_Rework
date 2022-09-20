using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject Bird;
    public bool Isfired = false;
    
    Animator anim;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Isfired == false)
        {          
            shoot();                    
        }
    }

    void shoot()
    {        
        Instantiate(Bird, Firepoint.position, Firepoint.rotation);
        Isfired = true;
        StartCoroutine(cooldown()); 
    }
    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(1f);
        Isfired = false;
    }

}
