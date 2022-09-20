using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npcdamage : MonoBehaviour
{
    public int Healthpoint = 3;
    public HPScript hp;
    public GameObject Player;
    bool Isimmune = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Player" && Isimmune == false)
        {
            getDamage();
            getImmune();           
        }
    }

    private void getDamage()
    {
        Debug.Log("Hit");
        hp.Damaged();
    }

    private void getImmune()
    {
        Isimmune = true;
        StartCoroutine(Iframe());
    }
    IEnumerator Iframe()
    {
        yield return new WaitForSeconds(3f);
        Isimmune = false;
    }
    public void Takedamaged(int damages)
    {
        if (Healthpoint <= 0)
        {
            Destroy(gameObject);
        }
        Healthpoint -= damages;
        Debug.Log("NPCHP = "+ Healthpoint);
        
    }
}
