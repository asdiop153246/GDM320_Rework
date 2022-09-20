using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbladder : MonoBehaviour
{
    private float vertical;
    private float speed = 3f;
    private bool isladder;
    private bool isclimbing;
    [SerializeField] private Rigidbody2D rb;

   
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isladder && Mathf.Abs(vertical) > 0f)
        {
            isclimbing = true;
        }
    }
    private void FixedUpdate()
    {
        IsClimbing();
    }
    private void IsClimbing()
    {
        if (isclimbing)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);

        }
        else
        {
            rb.gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isladder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isladder = false;
            isclimbing = false;
        }
    }
}
