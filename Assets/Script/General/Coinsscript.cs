using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coinsscript : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    public AudioClip coinSound;
    GameObject player;
    //public GameObject changejob;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
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
    private void Update()
    {
        //if (coinCount >= 20)
        //{
        //    Buymenu();
        //}
    }
    public void Buymenu()
    {
        //changejob.SetActive(true);
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
        //changejob.SetActive(false);
    }
}
