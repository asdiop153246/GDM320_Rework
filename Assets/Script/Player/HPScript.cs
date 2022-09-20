using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HPScript : MonoBehaviour
{
    public Image Life1, Life2, Life3, Life4, Life5;
    public void Damaged()
    {   
        HealthScript();
    }
    public void HealthScript()
    {
        if (Life5.gameObject.activeSelf == true)
        {
            Life5.gameObject.SetActive(false);
            calmdown();
        }
        else if (Life4.gameObject.activeSelf == true)
        {
            Life4.gameObject.SetActive(false);
            calmdown();
        }
        else if (Life3.gameObject.activeSelf == true)
        {
            Life3.gameObject.SetActive(false);
            calmdown();
        }
        else if (Life2.gameObject.activeSelf == true)
        {
            Life2.gameObject.SetActive(false);
            calmdown();
        }
        else if (Life1.gameObject.activeSelf == true)
        {
            Life1.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    IEnumerator calmdown()
    {
        yield return new WaitForSeconds(3f);
    }
}

