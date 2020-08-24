using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBoatZone : MonoBehaviour
{
	bool inZone = false;

	public GameObject waterBox;

	void Start()
	{
		inZone = false;
	}

	void Update()
	{
		if(inZone)
		{
			if(WaterBoxAnim.done)
			{
				WaterBoxAnim.done = false;
				PlayerStats.updateBoatInventory(1);
				if(PlayerStats.boatInventory < PlayerStats.BOAT_MAX_INVENTORY)
				{
					waterBox.GetComponent<Animator>().Play("waterBox");
				}
			}
		}
		else if(WaterBoxAnim.done)
		{
			WaterBoxAnim.done = false;
		}
	}



    void OnTriggerEnter2D(Collider2D col)
    {
    	if(PlayerStats.isBoatFactoryLinePurchased)
    	{
    		inZone = true;
    		waterBox.GetComponent<Animator>().Play("waterBox");
    	}
    }

    void OnTriggerExit2D(Collider2D col)
    {
    	inZone = false;
    }
}
