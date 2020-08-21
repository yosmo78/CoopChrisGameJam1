using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
	public const int BREAKING_VELOCITY = 2;

    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.relativeVelocity.magnitude > BREAKING_VELOCITY)
        {	Debug.Log("Over 2!");

        	if(CameraFollow.following == CameraFollow.truck) 
    		{
    			--PlayerStats.truckInventory;
    			if(PlayerStats.truckInventory < 0)
    			{
    				PlayerStats.truckInventory = 0;
    			}
    		}
    		else if(CameraFollow.following == CameraFollow.boat) 
    		{
    			--PlayerStats.boatInventory;
    			if(PlayerStats.boatInventory < 0)
    			{
    				PlayerStats.boatInventory = 0;
    			}
    		}
    		else if(CameraFollow.following == CameraFollow.tank) 
    		{
    			--PlayerStats.tankInventory;
    			if(PlayerStats.tankInventory < 0)
    			{
    				PlayerStats.tankInventory = 0;
    			}
    		}

    	}
    }
}
