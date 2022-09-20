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
            activeUI(true);
            activeInvadedzone();
            StartCoroutine(Endframe());
        }
    }
    IEnumerator Endframe()
    {
        yield return new WaitForSeconds(7f);
        setCameraToPlayer();
        activeUI(false);
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
    private void activeInvadedzone()
    {
        WIPline.SetActive(true);
        invadedzone.SetActive(true);
    }
    private void activeUI(bool IsActive)
    {
        UI.SetActive(IsActive);
        UI2.SetActive(IsActive);
    }
}
