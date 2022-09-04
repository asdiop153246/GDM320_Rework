using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Pause : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpause;
    Canvas canvas;
    public TMP_Text Pausetext;
    void Start()
    {
        canvas = GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            canvas.enabled = !canvas.enabled;
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            if (Time.timeScale == 0)
            {
                paused.TransitionTo(0.05f);
                Pausetext.SetText("Paused");
                Pausetext.gameObject.SetActive(true);
            }
            else
            {
                unpause.TransitionTo(0.05f);
                Pausetext.gameObject.SetActive(false);
            }
        }
    }
}
