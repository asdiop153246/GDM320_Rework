using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Coinsscript : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    public AudioClip coinSound;
    
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            coinCount++;
            coinText.text = coinCount.ToString();
            Destroy(other.gameObject);

        }
        if (coinCount > 5)
        {
          NextScene();
        }

    }

    public void IncreaseCoin(int NumberofCoin)
    {
        coinCount = coinCount + NumberofCoin;
        coinText.text = coinCount.ToString();
    }
    public void DecreaseCoin(int NumberofCoin)
    {
        coinCount = coinCount - NumberofCoin;
        coinText.text = coinCount.ToString();
    }
     public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
