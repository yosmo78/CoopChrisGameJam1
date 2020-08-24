using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public const int STARTING_INVENTORY = 0;
    public const int STARTING_MAX_INVENTORY = 5;
    public const int STARTING_BUILDING_MAX_INVENTORY = 25;

    public static int MAX_AMOUNT_TRUCK_INVENTORY_UPGRADES = 19;
    public static int amountTruckInventoryUpgrades = 0;

    public static int MAX_AMOUNT_BOAT_INVENTORY_UPGRADES = 19;
    public static int amountBoatInventoryUpgrades = 0;

    public static int MAX_AMOUNT_TANK_INVENTORY_UPGRADES = 19;
    public static int amountTankInventoryUpgrades = 0;

    public static int MAX_AMOUNT_TRUCK_PORT_INVENTORY_UPGRADES = 15;
    public static int amountTruckPortInventoryUpgrades = 0;

    public static int MAX_AMOUNT_TANK_PORT_INVENTORY_UPGRADES = 15;
    public static int amountTankPortInventoryUpgrades = 0;

    public static int TRUCK_MAX_INVENTORY = STARTING_MAX_INVENTORY;
    public static int BOAT_MAX_INVENTORY = STARTING_MAX_INVENTORY;
    public static int TANK_MAX_INVENTORY = STARTING_MAX_INVENTORY;

	public static int truckInventory = STARTING_INVENTORY;
	public static int boatInventory = STARTING_INVENTORY;
	public static int tankInventory = STARTING_INVENTORY;


    public static int TRUCK_PORT_MAX_INVENTORY = STARTING_BUILDING_MAX_INVENTORY;
    public static int TANK_PORT_MAX_INVENTORY = STARTING_BUILDING_MAX_INVENTORY;

    public static int truckPortInventory = STARTING_INVENTORY;
    public static int tankPortInventory = STARTING_INVENTORY;

	public static int money = 0;

    public static int TRUCK_BREAKING_VELOCITY = 2;
    public static int BOAT_BREAKING_VELOCITY = 2;
    public static int TANK_BREAKING_VELOCITY = 2;

    public static bool isKingBlessingPurchased = false;
    public static bool isQueensBlessingPurchased = false;
    public static bool isPirateMedallionPurchased = false;
    public static bool isBoatFactoryLinePurchased = false;

    public static bool truckInventoryHas(int amount)
    {
        if(truckInventory >= amount)
            return true;
        return false;
    }

    public static bool boatInventoryHas(int amount)
    {
        if(boatInventory >= amount)
            return true;
        return false;
    }

    public static bool tankInventoryHas(int amount)
    {
        if(tankInventory >= amount)
            return true;
        return false;
    }

    public static bool truckPortInventoryHas(int amount)
    {
        if(truckPortInventory >= amount)
            return true;
        return false;
    }

    public static bool tankPortInventoryHas(int amount)
    {
        if(tankPortInventory >= amount)
            return true;
        return false;
    }

    public static bool isBoatInventoryFull()
    {
        return boatInventory == BOAT_MAX_INVENTORY;
    }

    public static bool isTankInventoryFull()
    {
        return tankInventory == TANK_MAX_INVENTORY;
    }

    public static void updateTankInventory(int amount)
    {
        tankInventory = tankInventory + amount;
        if(tankInventory < 0)
        {
            tankInventory = 0;
        }
        else if(tankInventory > TANK_MAX_INVENTORY)
        {
            tankInventory = TANK_MAX_INVENTORY;
        }

    }


    public static void updateBoatInventory(int amount)
    {
        boatInventory = boatInventory + amount;
        if(boatInventory < 0)
        {
            boatInventory = 0;
        }
        else if(boatInventory > BOAT_MAX_INVENTORY)
        {
            boatInventory = BOAT_MAX_INVENTORY;
        }

        if(isQueensBlessingPurchased)
        {
            Boat.spriteRenderer.sprite = Boat.bathtub;
        }

    }

	public static void updateTruckInventory(int amount)
	{
		truckInventory = truckInventory + amount;
    	if(truckInventory < 0)
    	{
    		truckInventory = 0;
    	}
    	else if(truckInventory > TRUCK_MAX_INVENTORY)
    	{
    		truckInventory = TRUCK_MAX_INVENTORY;
    	}

        if(isKingBlessingPurchased)
        {
            Truck.spriteRenderer[1].sprite = Truck.toilet;
            Truck.spriteRenderer[0].sprite = Truck.flag;
            Truck.spriteRenderer[0].flipX = true;
        }
        else
        {
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
}
