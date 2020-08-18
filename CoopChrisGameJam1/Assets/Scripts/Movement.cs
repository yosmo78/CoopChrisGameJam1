using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float accelerationFactor = 0.005f;
    public float decelerationFactor = 0.005f;

    Vector2 acceleration;
    Vector2 velocity;



 public float timeFromZeroToMax = 2;  // How long it takes to reach max
 
 void Update ()
 {
     float moveTowardsX = 0;
     float moveTowardsY = 0;
     if (Input.GetAxisRaw("Horizontal") == 1)
     {
         moveTowardsX = 1.0f;
     }
     else if (Input.GetAxisRaw("Horizontal") == -1)
     {
         moveTowardsX = -1.0f;
     }

     if (Input.GetAxisRaw("Vertical") == 1)
     {
         moveTowardsY = 1.0f;
     }
     else if (Input.GetAxisRaw("Vertical") == -1)
     {
         moveTowardsY = -1.0f;
     }

     float changeRatePerSecondX = (moveTowardsX == 0?decelerationFactor:accelerationFactor) / timeFromZeroToMax * Time.deltaTime;
     float changeRatePerSecondY = (moveTowardsY == 0?decelerationFactor:accelerationFactor) / timeFromZeroToMax * Time.deltaTime;


     velocity.x = Mathf.MoveTowards (velocity.x, moveTowardsX, changeRatePerSecondX);
     velocity.y = Mathf.MoveTowards (velocity.y, moveTowardsY, changeRatePerSecondY);
 }



    void FixedUpdate()
    {

        //velocity += (accelerationFactor* acceleration.normalized* Time.deltaTime) + (-1.0f*decelerationFactor* velocity.normalized);
        Debug.Log(velocity.x);

        rb.position += velocity;

        rb.MovePosition(rb.position);

    }

}
