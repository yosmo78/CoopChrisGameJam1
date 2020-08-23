using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCacheBoatZone : MonoBehaviour
{

	public GameObject TruckPortUI;
    public GameObject EventSystem;
	public GameObject Boat;

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
    		Boat.GetComponent<Movement>().rb.velocity = new Vector3(0f,0f,0f);
    		Boat.SetActive(false); //maybe just disable Movement script
    		TruckPortUI.SetActive(true);
            EventSystem.GetComponent<PortCacheUI>().WithdrawBoatInventoryButton.interactable = true;
    	}
    	inZone = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
    	if(!inMenu)
    	{
            EventSystem.GetComponent<PortCacheUI>().WithdrawBoatInventoryButton.interactable = false;
    		inZone = false;
    	}	
    }
}
