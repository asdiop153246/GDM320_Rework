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
    
    // Start is called before the first frame update
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Playercam.SetActive(false);
            NPCcam.SetActive(true);
            UI.SetActive(true);
            UI2.SetActive(true);
            WIPline.SetActive(true);
            invadedzone.SetActive(true);
            StartCoroutine(Endframe());
        }
    }    
    IEnumerator Endframe()
    {
        yield return new WaitForSeconds(7f);

        Playercam.SetActive(true);
        NPCcam.SetActive(false);
        UI.SetActive(false);
        UI2.SetActive(false);
    }
}
