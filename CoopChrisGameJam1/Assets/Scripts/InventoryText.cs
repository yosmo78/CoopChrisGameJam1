using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryText : MonoBehaviour
{
    public Text text;

	public Vector3 offset = new Vector3(0f, 1.0f, 0f);
	
    // Update is called once per frame
    void Update()
    {
    	if(CameraFollow.following == CameraFollow.truck) 
    	{
    		text.text = PlayerStats.truckInventory+":"+PlayerStats.MAX_INVENTORY;
    	}
    	else if(CameraFollow.following == CameraFollow.boat) 
    	{
    		text.text = PlayerStats.boatInventory+":"+PlayerStats.MAX_INVENTORY;
    	}
    	else if(CameraFollow.following == CameraFollow.tank) 
    	{
    		text.text = PlayerStats.tankInventory+":"+PlayerStats.MAX_INVENTORY;
    	}
    	else
    	{
    		text.text = "0:0";
    	}

        transform.position = CameraFollow.following.transform.position + offset;
    }
}
