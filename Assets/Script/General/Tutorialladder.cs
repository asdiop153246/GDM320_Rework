using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tutorialladder : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text Talk;


    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Speech(Talk));
        }
    }
    IEnumerator Speech(TMP_Text speak)
    {
        speak.SetText("Press W,S to climb Ladder");
        Talk.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        speak.gameObject.SetActive(false);
    }

    // Update is called once per frame
}
