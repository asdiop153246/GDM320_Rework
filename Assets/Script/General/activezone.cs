using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activezone : MonoBehaviour
{
    public GameObject Zone;
    public GameObject PlayerCam;
    public GameObject NpcCam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Zone.SetActive(true);
            PlayerCam.SetActive(false);
            NpcCam.SetActive(true);
            StartCoroutine(Delays());
        }
    }
    IEnumerator Delays()
    {
        yield return new WaitForSeconds(3f);
        PlayerCam.SetActive(true);
        NpcCam.SetActive(false);
    }
    
}
