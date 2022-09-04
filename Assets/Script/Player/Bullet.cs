using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    private Npcdamage damage;
    public int damages = 1;
    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(decay());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            Debug.Log("I hit you Indian");
            damage = collision.GetComponent<Npcdamage>();
            damage.Takedamaged(damages);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            

        }
    }
    IEnumerator decay()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


    // Update is called once per frame

}
