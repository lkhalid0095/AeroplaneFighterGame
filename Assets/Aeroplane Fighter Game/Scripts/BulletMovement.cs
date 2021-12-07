using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    public GameObject playerOne;
    public AudioSource audio;
    public GameObject enemy;
    public GameObject controller;
    [SerializeField] float speed = 6;
    [SerializeField] bool isFlipped = false;
    const int RIGHT_MVMT = 1;
    const int LEFT_MVMT = -1;
    const int DEFAULT_LOST = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){ 
            
            rigid = GetComponent <Rigidbody2D>();
        }
        if(playerOne == null ){
            
            playerOne = GameObject.FindGameObjectWithTag("Player");

        }   
        if(enemy == null)
            enemy = GameObject.FindGameObjectWithTag("Opponent");
        
        if (audio == null)
            audio = GetComponent<AudioSource>();
        if(controller == null)
        
            controller = GameObject.FindGameObjectWithTag("GameController");
         


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //assigns boolean by getting the current face from the player mvmt script
        isFlipped = playerOne.GetComponent<PlayerOneMovement>().GetFace();
        //if the player is flipped then it'll call shootLeft
        //otherwise it'll call shootRight
         if(isFlipped){
                 shootLeft();
         } else{
             shootRight();
         }
        
    }


    //shoots bullets to the right
     public void shootRight(){
    
        rigid.AddForce(new Vector2(RIGHT_MVMT*speed, rigid.velocity.y));
    }
    
    //shoots bullet to the left 
     public void shootLeft(){
        rigid.AddForce(new Vector2(LEFT_MVMT*speed, rigid.velocity.y));
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collision between a bullet and opponent happens
        //destroy the opponeny

        if(collision.gameObject.CompareTag("Opponent"))
        {
            controller.GetComponent<PlayerHeath>().decEnemyHealth();
            controller.GetComponent<PlayerHeath>().addPoints();
            int health = controller.GetComponent<PlayerHeath>().getEHealth();
            int currentLevel = controller.GetComponent<PlayerHeath>().getLevel();
            
            audio.Play();
            
                //if player's health is zero, then destroy player, and next level
                if(health == DEFAULT_LOST){

                
                    Destroy(enemy);
                    controller.GetComponent<PlayerHeath>().AdvanceLevel();
                
            }   
            
        }

    }
}
