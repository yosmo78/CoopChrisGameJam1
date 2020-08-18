using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject truck = GameObject.Find("Truck");
    public GameObject boat;
    public GameObject tank;

    public Vector3 offset = new Vector3(0f, 0f, 0f);

    void Start()
    {

        transform.position = truck.transform.position + offset;

        truck.GetComponent<Movement>().enabled = true;
        boat.GetComponent<Movement>().enabled = false;
        tank.GetComponent<Movement>().enabled = false;

    }

    void Update()
    {
        


    }

    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) { SwapToTruck(); }

        if (Input.GetKeyDown(KeyCode.Alpha2)) { SwapToBoat(); }

        if (Input.GetKeyDown(KeyCode.Alpha3)) { SwapToTank(); }

    }


    void SwapToTruck()
    {

        transform.position = truck.transform.position + offset;
        truck.GetComponent<Movement>().enabled = true;
        boat.GetComponent<Movement>().enabled = false;
        tank.GetComponent<Movement>().enabled = false;


    }

    void SwapToBoat()
    {

        transform.position = boat.transform.position + offset;
        truck.GetComponent<Movement>().enabled = false;
        boat.GetComponent<Movement>().enabled = true;
        tank.GetComponent<Movement>().enabled = false;

    }

    void SwapToTank()
    {

        transform.position = tank.transform.position + offset;
        truck.GetComponent<Movement>().enabled = false;
        boat.GetComponent<Movement>().enabled = false;
        tank.GetComponent<Movement>().enabled = true;

    }

}
