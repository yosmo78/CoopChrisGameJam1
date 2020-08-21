using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
	bool inZone = false;

	public GameObject box;

	void Start()
	{
		inZone = false;
	}

	void Update()
	{
		if(inZone)
		{
			if(BoxAnim.done)
			{
				BoxAnim.done = false;
				PlayerStats.updateTruckInventory(1);
				if(PlayerStats.truckInventory < PlayerStats.MAX_INVENTORY)
				{
					box.GetComponent<Animator>().Play("boxMove5sec");
				}
			}
		}
		else if(BoxAnim.done)
		{
			BoxAnim.done = false;
		}
	}



    void OnTriggerEnter2D(Collider2D col)
    {
    	inZone = true;
    	box.GetComponent<Animator>().Play("boxMove5sec");
    }

    void OnTriggerExit2D(Collider2D col)
    {
    	inZone = false;
    }
}
