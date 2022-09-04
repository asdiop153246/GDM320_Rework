using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Changejob : MonoBehaviour
{
    public Sprite Knight;
    GameObject player;
    public GameObject Players;
    public Button Yes, No;
    public Image Menu;

    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knight"))
        {           
                buymenu();
            
        }
    }
    private void buymenu()
    {
        if (Menu.gameObject.activeSelf == false)
        {
            Menu.gameObject.SetActive(true);
            

            Yes.interactable = true;
            No.interactable = true;
            Yes.onClick.AddListener(Changesprite);
            No.onClick.AddListener(Cancel);
        }
    }
    private void Changesprite()
    {
        Players.gameObject.GetComponent<SpriteRenderer>().sprite = Knight;
        Menu.gameObject.SetActive(false);
        

        Yes.interactable = false;
        No.interactable = false;
        Players.GetComponent<Coinsscript>().DecreaseCoin(20);
    }
    private void Cancel()
    {
        Menu.gameObject.SetActive(false);
       

        Yes.interactable = false;
        No.interactable = false;
    }
}
