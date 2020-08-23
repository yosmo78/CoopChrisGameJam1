using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCacheZone : MonoBehaviour
{

	public GameObject TruckPortUI;
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
    		Truck.SetActive(false); //maybe just disable Movement script
    		TruckPortUI.SetActive(true);
    	}
    	inZone = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
    	if(!inMenu)
    	{
    		inZone = false;
    	}	
    }
}
