using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPCtalk : MonoBehaviour
{
    public TMP_Text Talk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Speech(Talk));
        }
    }
    IEnumerator Speech(TMP_Text speak)
    {
        Talk.SetText("Welcome to Night Village");
        Talk.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        Talk.gameObject.SetActive(false);
    }
}
