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

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Playercam.SetActive(false);
            NPCcam.SetActive(true);
            StartCoroutine(Speech(Talk));
            
        }
    }
    IEnumerator Speech(TMP_Text speak)
    {
        
        speak.SetText("Jump over the waterfall");
        Talk.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        speak.gameObject.SetActive(false);
        NPCcam.SetActive(false);
        Playercam.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
