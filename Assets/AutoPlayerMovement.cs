using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidBdy;
    [SerializeField] float speed = 5f;
    [SerializeField] bool isFacingRight = true;
    const int autoRight = -1;
    const int autoLeft = 1;
    const float xMin = -5.5f;
    const float xMax = 10;
    //const float yMin = 1;
    //const float yMax = 10;

    // Start is called before the first frame update
    void Start()
    {
           if (rigidBdy == null){ 
            
            rigidBdy = GetComponent <Rigidbody2D>();
        }
        //the autoplayer will start with moving across the screen 
        //unless it goes out of screenboundaries
        rigidBdy.velocity = new Vector2(autoRight * speed, rigidBdy.velocity.y);
    }

    void FixedUpdate(){
        boundaries();
    }
    public void boundaries(){

        float xPos = rigidBdy.transform.position.x;

        if( xPos <= xMin){
            westBound(xPos);
        }
           

        if(xPos >= xMax ){
            eastBound(xPos);    
        }
        
    }
    public void eastBound(float xPos){
         if(xPos > 0 && !isFacingRight || xPos < 0 && isFacingRight ){
            flip();
            }
            rigidBdy.AddForce(new Vector2(autoRight * speed, rigidBdy.velocity.y));

    }

    public void westBound(float xPos){

         if(xPos < 0 && isFacingRight || xPos > 0 && !isFacingRight ){
            flip();

        }
            rigidBdy.AddForce(new Vector2(autoLeft*speed,rigidBdy.velocity.y));
         

    }

      public void flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }
}
