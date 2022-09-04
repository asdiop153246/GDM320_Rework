using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activezone : MonoBehaviour
{
    public GameObject zone;
    public GameObject playercam;
    public GameObject npccam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zone.SetActive(true);
            playercam.SetActive(false);
            npccam.SetActive(true);
            StartCoroutine(Delays());
        }
    }
    IEnumerator Delays()
    {
        yield return new WaitForSeconds(3f);
        playercam.SetActive(true);
        npccam.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
