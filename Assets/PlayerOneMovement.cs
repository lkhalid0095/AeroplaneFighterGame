using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){ 
            
            rigid = GetComponent <Rigidbody2D>();
        }


    }

    // Update is called once per frame
    void Update(){
    
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical") ;

    }
    
    void FixedUpdate(){
        
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);
         if (horizontal > 0 && isFacingRight || horizontal < 0 && !isFacingRight)
            flip();
            rigid.AddForce(new Vector2(rigid.velocity.x, vertical* speed));
    }

    public void flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }
}