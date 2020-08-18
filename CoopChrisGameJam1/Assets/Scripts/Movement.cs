using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float accelerationFactor = 100.0f;
    public float decelerationFactor = 1.0f;
    public float timeFromZeroToMax = 2.0f;

    public float maxVelocity = 4.0f;

    Vector2 acceleration;
    //Vector2 velocity;


   // How long it takes to reach max
 
 void Update ()
 {

     float moveTowardsX = 0;
     float moveTowardsY = 0;

     if (Input.GetAxisRaw("Horizontal") == 1)
     {

         moveTowardsX = maxVelocity;

        }
     else if (Input.GetAxisRaw("Horizontal") == -1)
     {

         moveTowardsX = -maxVelocity;

     }

     if (Input.GetAxisRaw("Vertical") == 1)
     {

         moveTowardsY = maxVelocity;

     }
     else if (Input.GetAxisRaw("Vertical") == -1)
     {

         moveTowardsY = -maxVelocity;

     }

     float changeRatePerSecondX = ((moveTowardsX == 0?decelerationFactor:accelerationFactor) / timeFromZeroToMax) * Time.deltaTime;
     float changeRatePerSecondY = ((moveTowardsY == 0?decelerationFactor:accelerationFactor) / timeFromZeroToMax) * Time.deltaTime;


     float vx = Mathf.MoveTowards (rb.velocity.x, moveTowardsX, changeRatePerSecondX);

     if(vx > maxVelocity)
     {
        vx = maxVelocity;
     }
     else if (vx < -maxVelocity)
     {
        vx = -maxVelocity;
     }

     float vy = Mathf.MoveTowards (rb.velocity.y, moveTowardsY, changeRatePerSecondY);

     if(vy > maxVelocity)
     {
        vy = maxVelocity;
     }
     else if (vy < -maxVelocity)
     {
        vy = -maxVelocity;
     }

     rb.velocity = new Vector3(vx,vy,0);

     Vector2 moveDirection = rb.velocity;
     if (moveDirection != Vector2.zero) 
     {
         float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
     }



 }



    void FixedUpdate()
    {

    }

}
