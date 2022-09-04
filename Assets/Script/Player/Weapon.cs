using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject Bird;
    
    Animator anim;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //anim.SetTrigger("Attack");
            shoot();
        }
    }

    void shoot()
    {
        
        Instantiate(Bird, Firepoint.position, Firepoint.rotation);
        StartCoroutine(cooldown());
    }
    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(2f);
    }

}
