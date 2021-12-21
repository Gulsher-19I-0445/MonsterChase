using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 5f;
    // public float maxVelocity = 22f;
    private float movementX;
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string Ground_tag = "Ground";
    private string Enemy_tag = "Enemy";
    private bool isGrounded=false;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        animatePlayer();
        playerJump();
    }

    private void FixedUpdate()
    {
        playerJump();
    }

    void PlayerMove()		//FOR movement
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void animatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX=false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void playerJump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded) 
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
           // OnCollisionEnter2D(mybody);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_tag))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(Enemy_tag))
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Enemy_tag))
        {
            Destroy(gameObject);
        }

    }


}   //class
