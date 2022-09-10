using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class setActiveDialog : MonoBehaviour
{
    public TMP_Text Talk;

    public void setActiveTalk(bool value)
    {
        Talk.gameObject.SetActive(value);
    }
    public void setActiveSpeak(bool value)
    {
        speak.gameObject.SetActive(value);
    }
}
