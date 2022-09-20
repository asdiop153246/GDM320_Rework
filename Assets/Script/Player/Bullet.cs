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
        bulletMovement();
        StartCoroutine(decay());
    }
    private void bulletMovement()
    {
        rb.velocity = transform.right * speed;
    }
    IEnumerator decay()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            Debug.Log("I hit you Indian");
            damage = collision.GetComponent<Npcdamage>();
            damage.Takedamaged(damages);
            destroyObj(collision);
        }
    }
    private void destroyObj(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
