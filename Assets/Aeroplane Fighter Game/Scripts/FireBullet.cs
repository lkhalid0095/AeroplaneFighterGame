using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject controller;
    public GameObject player;
    public GameObject bullet;
    public GameObject enemy;
    public GameObject enemyBullet;
    //public AudioSource audio;
    [SerializeField] float oneXPos; //find player x position
    [SerializeField] float oneYPos; // find player y position
    [SerializeField] float eXPos; //find enemy x position
    [SerializeField] float eYPos; // find enemy y position
    [SerializeField] bool spacePressed = false; 
    const int WAIT = 2; //wait 2 seconds before destroying the bullet
    const float ADJUST_XPOS = 1; //for both bullets
    const float ADJUST_YPOS = .23f; //for bullet 1
    const float ADJUST_YPOS2 = .67f; //for bullet 2
    const int Z_POS = -1; //Z pos of bullet
    const int ROTATE = 180; //rotates bullet 180 degrees
    const float REPEAT_RATE = .6f; //rate of firing
    const float WAIT_TIME = .5f; //wait  before shooting
   
    // Start is called before the first frame update
    void Start()
    {

        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        // if (audio == null)
        //     audio = GetComponent<AudioSource>();

        if(bullet == null)
            bullet = GameObject.FindGameObjectWithTag("PlayerFire");
        
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        
        if(enemyBullet == null)
            enemyBullet = GameObject.FindGameObjectWithTag("EnemyFire");
        
        if(enemy == null)
            enemy = GameObject.FindGameObjectWithTag("Opponent");
        
        InvokeRepeating("enemyFire", WAIT_TIME, REPEAT_RATE);
    
    }

    // Update is called once per frame
    void Update()
    { 
        //you want one bullet to be executed when space is presse
     
          if (Input.GetKeyDown (KeyCode.Space)&& !spacePressed)   
          {
             fire();
             spacePressed=true;
          }
          else if (Input.GetKeyUp (KeyCode.Space))   
          {
              spacePressed=false;
              
          }
    
    }


 
    private void fire(){
        //finds player position, so the bullet is based off near there
        oneXPos = player.transform.position.x;
        oneYPos = player.transform.position.y;
       
       //checks if the player gameobject is flipped by using the getter
       //rotates bullet if it's flipped
        if(player.GetComponent<PlayerOneMovement>().GetFace()){
            //position of bullet
            Vector3 position = new Vector3(oneXPos-ADJUST_XPOS , oneYPos-ADJUST_YPOS,Z_POS);
            Vector3 rot = transform.rotation.eulerAngles;
            //rotates the bullet
             rot = new Vector3(rot.x, rot.y, rot.z + ROTATE);
             GameObject bulletSpawn = (GameObject)Instantiate(bullet,position,Quaternion.Euler(rot));
             //destroys the bullet after a certain amount of seconds
            Destroy(bulletSpawn,WAIT);
             
        } else{
            //if it's not flipped then a bullet is created based on player position
            Vector3 position2 = new Vector3(oneXPos+ADJUST_XPOS , oneYPos - ADJUST_YPOS2,Z_POS);
            GameObject bulletSpawn2 = (GameObject)Instantiate(bullet,position2,Quaternion.identity);
            Destroy(bulletSpawn2,WAIT);
            
        }

      }
      private void enemyFire(){
        //finds player position, so the bullet is based off near there
        eXPos = enemy.transform.position.x;
        eYPos = enemy.transform.position.y;
       
       //checks if the player gameobject is flipped by using the getter
       //rotates bullet if it's flipped
        if(enemy.GetComponent<AutoPlayerMovement>().GetFace()){
            //position of bullet
            Vector3 position = new Vector3(eXPos-ADJUST_XPOS , eYPos-ADJUST_YPOS,Z_POS);
            Vector3 rot = transform.rotation.eulerAngles;
            //rotates the bullet
             rot = new Vector3(rot.x, rot.y, rot.z + ROTATE);
             GameObject bulletSpawn = (GameObject)Instantiate(enemyBullet,position,Quaternion.Euler(rot));
             //destroys the bullet after a certain amount of seconds
            Destroy(bulletSpawn,WAIT);
             
        } else{
            //if it's not flipped then a bullet is created based on player position
            Vector3 position2 = new Vector3(eXPos+ADJUST_XPOS , eYPos - ADJUST_YPOS2,Z_POS);
            GameObject bulletSpawn2 = (GameObject)Instantiate(enemyBullet,position2,Quaternion.identity);
            Destroy(bulletSpawn2,WAIT);
            
        }
      }

    //   void CheckIfTimeToFire()
    //     {
    //       if(Time.time > nextFire)
    //       {
    //         nextFire = Time.time + fireRate;
    //         enemyFire();
            
    //       }
    //     }

     
}