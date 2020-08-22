using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeZoneCity : MonoBehaviour
{

	public GameObject TruckUpgradeUI;
	public GameObject Truck;

	bool inZone = false;
	public bool inMenu = false;

	void Start()
	{
		inZone = false;
	}

	void Update()
	{
		if(inZone)
		{

		}

	}



    void OnTriggerEnter2D(Collider2D col)
    {
    	if(!inMenu && !inZone)
    	{
    		inMenu = true;
    		Truck.GetComponent<Movement>().rb.velocity = new Vector3(0f,0f,0f);
    		Truck.SetActive(false);
    		TruckUpgradeUI.SetActive(true);
    	}
    	inZone = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
    	Debug.Log("Outta Here!");
    	if(!inMenu)
    	{
    		inZone = false;
    	}	
    }
}
