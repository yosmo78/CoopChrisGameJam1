using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortCacheTankZone : MonoBehaviour
{

	public GameObject TankPortUI;
	public GameObject EventSystem;
	public GameObject Tank;

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
    		Tank.GetComponent<Movement>().rb.velocity = new Vector3(0f,0f,0f);
    		Tank.SetActive(false); //maybe just disable Movement script
    		TankPortUI.SetActive(true);
    		EventSystem.GetComponent<PortTankCacheUI>().WithdrawTankInventoryButton.interactable = true;
    	}
    	inZone = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
    	if(!inMenu)
    	{
    		EventSystem.GetComponent<PortTankCacheUI>().WithdrawTankInventoryButton.interactable = false;
    		inZone = false;
    	}	
    }
}
