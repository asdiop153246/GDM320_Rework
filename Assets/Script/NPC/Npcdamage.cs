using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npcdamage : MonoBehaviour
{
    public int Healthpoint = 3;
    public HPScript hp;
    public GameObject Player;
    bool immune = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == "Player" && immune == false)
        {
            getDamage();
            getImmune();
            //Destroy(gameObject);
        }
    }

    private void getDamage()
    {
        Debug.Log("I slap your ass again");
        hp.Damaged();
    }

    private void getImmune()
    {
        immune = true;
        StartCoroutine(Iframe());
    }
    IEnumerator Iframe()
    {
        yield return new WaitForSeconds(3f);
        immune = false;
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
