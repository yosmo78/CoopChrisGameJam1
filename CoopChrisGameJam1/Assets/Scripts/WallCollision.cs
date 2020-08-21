using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
	public const int BREAKING_VELOCITY = 2;

	public int slowDown = 1;

    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.relativeVelocity.magnitude > BREAKING_VELOCITY)
        {	Debug.Log("Over 2!");




        	if(CameraFollow.following == CameraFollow.truck) 
    		{
    			Rigidbody2D rb = GameObject.Find("Truck").GetComponent<Movement>().rb;
    			rb.velocity = slowDown*rb.velocity.normalized;
    			PlayerStats.updateTruckInventory(-1);
    		}
    		else if(CameraFollow.following == CameraFollow.boat) 
    		{
    			Rigidbody2D rb = GameObject.Find("Boat").GetComponent<Movement>().rb;
    			rb.velocity = slowDown*rb.velocity.normalized;

    			--PlayerStats.boatInventory;
    			if(PlayerStats.boatInventory < 0)
    			{
    				PlayerStats.boatInventory = 0;
    			}
    		}
    		else if(CameraFollow.following == CameraFollow.tank) 
    		{
    			Rigidbody2D rb = GameObject.Find("Tank").GetComponent<Movement>().rb;
    			rb.velocity = slowDown*rb.velocity.normalized;

    			--PlayerStats.tankInventory;
    			if(PlayerStats.tankInventory < 0)
    			{
    				PlayerStats.tankInventory = 0;
    			}
    		}

    	}
    }
}
