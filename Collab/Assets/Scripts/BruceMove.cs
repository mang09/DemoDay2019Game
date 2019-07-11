using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruceMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shoot;
    public KeyCode punch;
    public KeyCode kick;


    private Rigidbody2D therb;
    
    public Transform GroundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask whatIsGround;
    
    public bool isGrounded;
    
    private Animator anim;
    
    public GameObject FireBall;
    public Transform throwPoint;
    bool canShoot;

    public AudioSource throwSound;
    public AudioSource projectileSound;

    // Start is called before the first frame update
    void Start()
    {
        therb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
    
        isGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, whatIsGround);
    
        if(Input.GetKey(left))
        {
            therb.velocity = new Vector2(-moveSpeed, therb.velocity.y);
        } else if(Input.GetKey(right))
        {
            therb.velocity = new Vector2(moveSpeed, therb.velocity.y);
        } else 
        {
            therb.velocity = new Vector2(0, therb.velocity.y);
        }
        if(Input.GetKeyDown(jump) && isGrounded)
        {
            therb.velocity = new Vector2(therb.velocity.x, jumpForce);
        }
        if(Input.GetKeyDown(shoot) && canShoot == true)
        {
            GameObject fireClone = (GameObject)Instantiate(FireBall, throwPoint.position, throwPoint.rotation);
            fireClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Shoot");
            canShoot = false;
            StartCoroutine(WaitAfterShoot());
            projectileSound.Play();
        }
        if(Input.GetKeyDown(punch))
        {
            anim.SetTrigger("Punch");
            throwSound.Play();
        }
        if(Input.GetKeyDown(kick))
        {
            
            anim.SetTrigger("Kick");
            throwSound.Play();
        }
        if(therb.velocity.x <0)
        {
            transform.localScale = new Vector3(-5,5,1);
        }else if(therb.velocity.x >0)
        {
            transform.localScale = new Vector3(5,5,1);
        }
        anim.SetFloat("Speed", Mathf.Abs(therb.velocity.x));
        anim.SetBool("Jump", isGrounded);


        
    }
    
    IEnumerator WaitAfterShoot()
    {
        yield return new WaitForSeconds(2);
        canShoot = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
     
    }
}
