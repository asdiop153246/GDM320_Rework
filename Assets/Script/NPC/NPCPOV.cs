using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;


public class NPCPOV : MonoBehaviour
{
    public TMP_Text Talk;
    public GameObject Playercam, NPCcam;
    public GameObject Char;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            setCameraToNPC();
            StartCoroutine(Speech(Talk));
        }
    }
    IEnumerator Speech(TMP_Text speak)
    {
        speak.SetText("Jump over the waterfall");
        setActiveTalk(true);

        yield return new WaitForSeconds(3);

        setActiveSpeak(speak , false);
        setCameraToPlayer();
    }
    private void setActiveTalk(bool value)
    {
        Talk.gameObject.SetActive(value);
    }
    private void setActiveSpeak(TMP_Text speak, bool value)
    {
        speak.gameObject.SetActive(value);
    }
    private void setCameraToNPC()
    {
        Playercam.SetActive(false);
        NPCcam.SetActive(true);
    }
    private void setCameraToPlayer()
    {
        NPCcam.SetActive(false);
        Playercam.SetActive(true);
    }

}
