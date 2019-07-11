using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;
    public KeyCode punch;
    public KeyCode Kick;
    
    private Rigidbody2D theRB;
    
    public Transform GroundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask whatIsGround;
    
    public bool isGrounded;
    
    private Animator anim;
    
    public GameObject fireBall;
    public Transform throwPoint;
    bool canShoot;

    public AudioSource throwSound;
    public AudioSource projectileSound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
         isGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, whatIsGround);
    
        if(Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        } else if(Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else 
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
        if(Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
        if(Input.GetKeyDown(shoot) && canShoot == true)
        {
             GameObject fireClone = (GameObject)Instantiate(fireBall, throwPoint.position, throwPoint.rotation);
            fireClone.transform.localScale = transform.localScale;
             anim.SetTrigger("Shoot");
             canShoot = false;
             StartCoroutine(WaitShoot());
             projectileSound.Play();
        }
        if(Input.GetKeyDown(punch))
        {
             anim.SetTrigger("Punch");
             throwSound.Play();
        }
        if(Input.GetKeyDown(Kick))
        {
             anim.SetTrigger("Kick");
             throwSound.Play();
        }
        if(theRB.velocity.x <0)
        {
            transform.localScale = new Vector3(5,5,1);
        }else if(theRB.velocity.x >0)
        {
            transform.localScale = new Vector3(-5,5,1);
        }
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Jump", isGrounded);
    }
    IEnumerator WaitShoot()
    {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }
      
    }
}
