using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int STARTING_INVENTORY = 0;
    public const int MAX_INVENTORY = 5;

	public static int truckInventory = STARTING_INVENTORY;
	public static int boatInventory = STARTING_INVENTORY;
	public static int tankInventory = STARTING_INVENTORY;

	public static int money = 0;


	public static void updateTruckInventory(int amount)
	{
		truckInventory = truckInventory + amount;
    	if(truckInventory < 0)
    	{
    		truckInventory = 0;
    	}
    	else if(truckInventory > MAX_INVENTORY)
    	{
    		truckInventory = MAX_INVENTORY;
    	}


    	if(truckInventory > 0)
    	{

    		Truck.spriteRenderer[0].sprite = Truck.fullTruckFront;
    		Truck.spriteRenderer[1].sprite = Truck.fullTruckBack;
    	}
    	else
    	{
    		Truck.spriteRenderer[0].sprite = Truck.emptyTruckFront;
    		Truck.spriteRenderer[1].sprite = Truck.emptyTruckBack;
    	}
	}
}
