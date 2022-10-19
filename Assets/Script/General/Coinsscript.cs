using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
}
