using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidBdy;
    [SerializeField] float speed = 5f;
    [SerializeField] bool isFacingRight = true;
    public GameObject enemy; 
    const int AUTO_RIGHT = -1; //moves right
    const int AUTO_LEFT = 1; //moves left
    const float X_MIN = -5.5f; //a boundary along the neg x-axis
    const float X_MAX = 10; //a boundary along the pos x-axis
    //const float Y_MIN = 1;
    //const float Y_MAX = 10;

    // Start is called before the first frame update
    void Start()
    {
           if (rigidBdy == null){ 
            
            rigidBdy = GetComponent <Rigidbody2D>();
        }
          if(enemy == null)
            enemy = GameObject.FindGameObjectWithTag("Opponent");
        
        //the autoplayer will start with moving across the screen 
        //unless it goes out of screenboundaries
        rigidBdy.velocity = new Vector2(AUTO_RIGHT * speed, rigidBdy.velocity.y);
    }

    void FixedUpdate(){
        boundaries();
    }
    public void boundaries(){
        //obtains the x position of the enemy player
        float xPos = rigidBdy.transform.position.x;
        //checks if the enemy is going out of screen boundaries
        if( xPos <= X_MIN){
            //if it does then it calls westbound
            westBound(xPos);
        }
           
        //checks if the enemy is going out of screen boundaries
        if(xPos >= X_MAX ){
            
            //if it does then it calls eastbound
            eastBound(xPos);    
        }
        
    }
    //method that takes in the enemy current position as argument
    public void eastBound(float xPos){
        //if the position of enemy needs to be flipped
         if(xPos > 0 && !isFacingRight || xPos < 0 && isFacingRight ){
            flip();
            }
            //add force to move the towards the east 
            rigidBdy.AddForce(new Vector2(AUTO_RIGHT * speed, rigidBdy.velocity.y));

    }

    public void westBound(float xPos){
        //if the position of enemy needs to be flipped
         if(xPos < 0 && isFacingRight || xPos > 0 && !isFacingRight ){
            flip();

        }
            //add force to moe towards the west
            rigidBdy.AddForce(new Vector2(AUTO_LEFT*speed,rigidBdy.velocity.y));
         

    }
    //flips the orientatino of sprite
      public void flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }
    
    //created a getter to return the current orientation of the player
    public bool GetFace(){
        return isFacingRight;
    }
}
