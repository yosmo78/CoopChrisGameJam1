﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
	bool inZone = false;

	public GameObject box;
	public Animation anim;

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
				if(PlayerStats.truckInventory >= PlayerStats.MAX_INVENTORY-1)
				{
					PlayerStats.truckInventory = PlayerStats.MAX_INVENTORY;
				}
				else
				{
					++PlayerStats.truckInventory;
					box.GetComponent<Animator>().Play("boxMove5sec");
				}
			}
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