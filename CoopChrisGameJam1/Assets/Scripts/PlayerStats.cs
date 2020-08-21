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
}
