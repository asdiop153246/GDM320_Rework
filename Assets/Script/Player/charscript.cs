using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class charscript : MonoBehaviour
{
    public float jumpforce = 250f;
    public float speed = 20f;
    float Horizontalmove = 0f;
    public bool jump = false;
    bool Isgamestarted = false;
    bool Isplatform = false;
    bool Isladder = false;
    private bool m_FacingRight = true;
    float move;
    Rigidbody2D rigidbody;
    Animator anim;
    AudioSource audioSource;
    SwapCamera camera;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        camera = GetComponent<SwapCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move * speed * Time.deltaTime, 0, 0);
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (Input.GetButtonDown("Jump"))
        {
            if ((Isplatform == true) && (Isgamestarted == true))
            {
                jump = true;
                Isplatform = false;
                audioSource.Play();

            }
            else
            {
                Isgamestarted = true; 
                
            }
            anim.SetBool("Platform", Isplatform);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Isplatform = true;
        Isladder = true;
    }
    private void FixedUpdate()
    {
        
            
            
        
        if (jump == true)
        {
            rigidbody.AddForce(new Vector2(0f, jumpforce));
            jump = false;
        }
        if ( move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
            
        }
            
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    public void RunLeft()
    {
        if (m_FacingRight == true)
        {
            Flip();
        }
        move = 5.0f;
        rigidbody.velocity = new Vector2(-move, rigidbody.velocity.x);
        anim.SetFloat("Speed", -Mathf.Abs(move));
    }

    public void RunRight()
    {
        if (m_FacingRight == false)
        {
            Flip();
        }
        move = 5.0f;
        rigidbody.velocity = new Vector2(move, rigidbody.velocity.x);
        anim.SetFloat("Speed", Mathf.Abs(move));
    }
     public void StopMoving()
    {
        rigidbody.velocity = Vector2.zero;
    }
    public void Jump()
    {
        
            rigidbody.AddForce(new Vector2(0f, jumpforce));              
    }
}
