using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeZoneOcean : MonoBehaviour
{

	public GameObject BoatUpgradeUI;
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
    		Boat.SetActive(false);
    		BoatUpgradeUI.SetActive(true);
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
