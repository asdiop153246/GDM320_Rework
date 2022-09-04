using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.UI; 
public class SwapCamera : MonoBehaviour
{

    public GameObject maincamera, character;
    public GameObject playercamobj, startcamobj;
    
    public TMP_Text Starttext;
    public TMP_Text tutorialtext;
    public Image HPbar;
    CinemachineBrain CinemachineBrain;
    public bool isGamestarted = false;
    private void Start()
    {
        Starttext.SetText("Press Enter to Start");
        CinemachineBrain = maincamera.GetComponent<CinemachineBrain>();
        character.GetComponent<charscript>().enabled = false;
        startcamobj.SetActive(true);
        playercamobj.SetActive(false);

    }
    
    void Update()
    {
        if (Input.GetButtonDown("Submit")||Input.GetButtonDown("Fire1"))
        {
            isGamestarted = true;
            startcamobj.SetActive(false);
            playercamobj.SetActive(true);
            HPbar.gameObject.SetActive(true);
        }

        if (isGamestarted == true)
        {
            character.GetComponent<charscript>().enabled = true;
            Starttext.gameObject.SetActive(false);
            
            StartCoroutine(DisplayTextWithDelay(tutorialtext));
            tutorialtext.gameObject.SetActive(false);
        }

        
    }
    
    IEnumerator DisplayTextWithDelay(TMP_Text text0bj)
    {
        text0bj.SetText("A,D to move space to jump");
        tutorialtext.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
         
    }
}
