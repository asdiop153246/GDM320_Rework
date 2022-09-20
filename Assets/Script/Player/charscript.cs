using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class charscript : MonoBehaviour
{
    public float jumpforce = 200f;
    public float speed = 20f;
    float Horizontalmove = 0f;
    public bool Isjump = false;
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
        onJump();
    }

    private void onJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            checkPlatform();
            anim.SetBool("Platform", Isplatform);
        }
    }
    private void checkPlatform()
    {
        if ((Isplatform == true) && (Isgamestarted == true))
        {
            Isjump = true;
            Isplatform = false;
            Jumpreset();
            audioSource.Play();
        }
        else
        {
            Isgamestarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Isplatform = true;
        Isladder = true;
    }
    private void FixedUpdate()
    {
        //Jumpreset();
        IsFlip();
        IsFire();
    }

    private void Jumpreset()
    {
        if (Isjump == true)
        {
            rigidbody.AddForce(new Vector2(0f, jumpforce));
            StartCoroutine(jumpdelay());       
        }
    }
    IEnumerator jumpdelay()
    {
        yield return new WaitForSeconds(2f);
        Isjump = false;
    }

    private void IsFlip()
    { 
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
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    private void IsFire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Attack");
        }
    }
    public void RunLeft()
    {
        IsFacingRight();
        move = 5.0f;
        rigidbody.velocity = new Vector2(-move, rigidbody.velocity.x);
        anim.SetFloat("Speed", -Mathf.Abs(move));
    }

    private void IsFacingRight()
    {
        if (m_FacingRight == true)
        {
            Flip();
        }
    }
    public void RunRight()
    {
        IsFacingLeft();
        move = 5.0f;
        rigidbody.velocity = new Vector2(move, rigidbody.velocity.x);
        anim.SetFloat("Speed", Mathf.Abs(move));
    }
    private void IsFacingLeft()
    {
        if (m_FacingRight == false)
        {
            Flip();
        }
    }

     public void StopMoving()
    {
        rigidbody.velocity = Vector2.zero;
    }
    public void Jump()
    {
        if (Isjump == false)
        {
            Isjump = true;
            Jumpreset();
        }
    }
}

