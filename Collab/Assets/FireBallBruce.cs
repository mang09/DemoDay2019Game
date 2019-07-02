using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBruce : MonoBehaviour
{
    public float BallSpeed;
    
    private Rigidbody2D therb;
    
    public GameObject fireBallEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        therb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        therb.velocity = new Vector2(BallSpeed * transform.localScale.x, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(fireBallEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
