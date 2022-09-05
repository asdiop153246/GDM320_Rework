using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class TalktoKing : MonoBehaviour
{
    public GameObject Playercam, NPCcam;
    public GameObject Char;
    public GameObject UI;
    public GameObject UI2;
    public GameObject WIPline;
    public GameObject invadedzone;
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            setCameraToNPC();
            activeUI();
            StartCoroutine(Endframe());
        }
    }
    IEnumerator Endframe()
    {
        yield return new WaitForSeconds(7f);
        setCameraToPlayer();
        unactiveUI();
    }
    private void setCameraToNPC()
    {
        Playercam.SetActive(false);
        NPCcam.SetActive(true);
    }
    private void setCameraToPlayer()
    {
        Playercam.SetActive(true);
        NPCcam.SetActive(false);
    }
    private void activeUI()
    {
        UI.SetActive(true);
        UI2.SetActive(true);
        WIPline.SetActive(true);
        invadedzone.SetActive(true);
    }
    private void unactiveUI()
    {
        UI.SetActive(false);
        UI2.SetActive(false);
    }
}
