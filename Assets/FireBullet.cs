using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject controller;
    public GameObject bullet;
    public GameObject playerOne;
    public AudioSource audio;
    [SerializeField] float oneXPos;
    [SerializeField] float oneYPos;
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        if (audio == null)
            audio = GetComponent<AudioSource>();

        if(bullet == null)
            bullet = GameObject.FindGameObjectWithTag("Fire");
        if(playerOne ==null)
           playerOne = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        fire();
        
    }
    void FixedUpdate(){
    }

    private void fire(){
        oneXPos = playerOne.transform.position.x;
        oneYPos = playerOne.transform.position.y;
        if (Input.GetKey("space")){
            Vector3 position = new Vector3(oneXPos + 2, oneYPos-.67f,-1);
            Instantiate(bullet, position, Quaternion.identity);
        }

    }
     private void OnTriggerEnter2D(Collider2D collision)
    {

        AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        Destroy(gameObject); //destroys itself after points have been added 
    }
}
