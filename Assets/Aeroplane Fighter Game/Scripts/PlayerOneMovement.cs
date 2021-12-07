using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    const int AUTO_RIGHT = -1; //moves right
    const int AUTO_LEFT = 1; //moves left
    public bool isFacingRight = true;
    // [SerializeField] Animator anim;
    // const int NOT_BLASTED = 0;
    // const int BLASTED = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){ 
            
            rigid = GetComponent <Rigidbody2D>();

        }
        // if (anim == null)
        //     anim = GetComponent<Animator>();
        // anim.SetInteger("blast", NOT_BLASTED);


    }


    // Update is called once per frame
    void Update(){
        //gets user input on both axis
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical") ;

        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
 
            if(screenPos.x < -5.5){
                rigid.velocity = new Vector2(AUTO_RIGHT * speed, rigid.velocity.y);

                //rigid.velocity = screenPos.x;
            }
 
            else if(screenPos.x >= Screen.width)
                rigid.velocity = new Vector2(AUTO_LEFT * speed, rigid.velocity.y);
                //rigid.velocity  = screenPos.x;

        
    }
    
    void FixedUpdate(){
        //
        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);
         if (horizontal > 0 && isFacingRight || horizontal < 0 && !isFacingRight)
            flip();
            rigid.velocity = new Vector2(rigid.velocity.x, vertical* speed);
    }
    
    //flips the sprite over y axis
    public void flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }

    //created a getter to return the current orientation of the player
    public bool GetFace(){
        return isFacingRight;
    }

}