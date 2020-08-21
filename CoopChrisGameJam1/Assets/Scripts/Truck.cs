using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
	public SpriteRenderer[] spriteRenderer;
    public Sprite emptyTruckBack;
    public Sprite emptyTruckFront;
    public Sprite fullTruckBack;
    public Sprite fullTruckFront;
    void Start()
    {
       spriteRenderer =  this.GetComponentsInChildren<SpriteRenderer>();
    }

    //maybe move this in an update truck inventory function
    void Update()
    {
    	if(PlayerStats.truckInventory > 0)
    	{
    		foreach(SpriteRenderer sp in spriteRenderer) {
           		if(sp.CompareTag("truckFront")) {
           			sp.sprite = fullTruckFront;
      	    	}
      	    	if(sp.CompareTag("truckBack")) {
           			sp.sprite = fullTruckBack;
      	    	}
      		}
    	}
    	else
    	{
    		foreach(SpriteRenderer sp in spriteRenderer) {
           		if(sp.CompareTag("truckFront")) {
           			sp.sprite = emptyTruckFront;
      	    	}
      	    	if(sp.CompareTag("truckBack")) {
           			sp.sprite = emptyTruckBack;
      	    	}
      		}
    	}

    }
}
