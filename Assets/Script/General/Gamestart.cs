using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamestart : MonoBehaviour
{
    private int coinCount;
    public TMP_Text coinText;
    public AudioClip coinSound;

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
}
