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
            Debug.Log("I slap your ass again");
            hp.Damaged();
            immune = true;
            StartCoroutine(Iframe());
            //Destroy(gameObject);
        }
    }
    IEnumerator Iframe()
    {
        
        yield return new WaitForSeconds(3f);
        immune = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Takedamaged(int damages)
    {
        if (Healthpoint <= 0)
        {
            Destroy(gameObject);
        }
        Healthpoint -= damages;
        Debug.Log("NPCHP = "+ Healthpoint);
        
    }
    void Update()
    {
        
    }
}
