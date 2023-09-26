using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerShoot2D : MonoBehaviour
{
    private Animator anim;
    public float speed = 8.0f;
    public float jumpForce = 20.0f;
    public Transform groundCheck;
    public bool isFacingRight = true;
    public float bulletSpeed = 100.0f;
    public float bulletTime = 5.0f;
    public GameObject bullet;
    public Transform bulletPos;
    Rigidbody2D rb;
    float horizontal;
    public GameObject ShootAnim;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ShootAnim.SetActive(true);
            Invoke("Stop", 0.2f);
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject obj;
            if (bulletSpeed > 0)
            {
                obj = Instantiate(bullet, bulletPos.position, Quaternion.Euler(0, 0, 0));
            }
            else
            {
                obj = Instantiate(bullet, bulletPos.position, Quaternion.Euler(0, 0, 180));
            }

            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0) * bulletSpeed);
            Destroy(obj, bulletTime);
        }

        Flip();
    }

    void FixedUpdate()
    {
        if (horizontal==0)
        {
            anim.enabled = false;
        }
        else
        {
            anim.enabled = true;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f);
        if (colliders.Length > 1) // my collider and ground collider
        {
            return true;
        }
        else
        {
            return false;
        }
    }

     void Stop()
    {
        ShootAnim.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
    }


        void Flip()
    {
        if (isFacingRight == true && horizontal < 0f || isFacingRight == false && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            bulletSpeed = -bulletSpeed;
        }
    }
}
