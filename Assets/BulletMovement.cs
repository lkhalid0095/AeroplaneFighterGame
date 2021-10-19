using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 6;
    const int rightmvmt = 1;
    const int xMax = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){ 
            
            rigid = GetComponent <Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shootRight();
        
    }

    public void shootRight(){
    
        rigid.velocity = new Vector2(rightmvmt*speed, rigid.velocity.y);
    }
}
