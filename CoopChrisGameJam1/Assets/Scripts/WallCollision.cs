using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{

	public int slowDown = 1;

    void OnCollisionEnter2D(Collision2D col)
    {

        if((col.gameObject.ToString() == CameraFollow.truck.ToString()  && col.relativeVelocity.magnitude > PlayerStats.TRUCK_BREAKING_VELOCITY) ||
        (col.gameObject.ToString() == CameraFollow.boat.ToString() && col.relativeVelocity.magnitude > PlayerStats.BOAT_BREAKING_VELOCITY) ||
        (col.gameObject.ToString() == CameraFollow.tank.ToString() && col.relativeVelocity.magnitude > PlayerStats.TANK_BREAKING_VELOCITY) )
        {	
        	if(col.gameObject.ToString() == CameraFollow.truck.ToString() ) 
    		{
    			Rigidbody2D rb = GameObject.Find("Truck").GetComponent<Movement>().rb;
    			rb.velocity = slowDown*rb.velocity.normalized;
    			PlayerStats.updateTruckInventory(-1);
    		}
    		else if(col.gameObject.ToString() == CameraFollow.boat.ToString() ) 
    		{
    			Rigidbody2D rb = GameObject.Find("Boat").GetComponent<Movement>().rb;
    			rb.velocity = slowDown*rb.velocity.normalized;

    			--PlayerStats.boatInventory;
    			if(PlayerStats.boatInventory < 0)
    			{
    				PlayerStats.boatInventory = 0;
    			}
    		}
    		else if(col.gameObject.ToString() == CameraFollow.tank.ToString() ) 
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
