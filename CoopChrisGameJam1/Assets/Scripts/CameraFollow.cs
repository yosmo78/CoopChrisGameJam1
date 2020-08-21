using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject truck;
    public GameObject boat;
    public GameObject tank;

    public Vector3 offset = new Vector3(0f, 0f, 0f);

    public static GameObject following;

    void Start()
    {

        transform.position = truck.transform.position + offset;

        truck.GetComponent<Movement>().enabled = true;
        boat.GetComponent<Movement>().enabled = false;
        tank.GetComponent<Movement>().enabled = false;

        following = truck;

    }

    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) { SwapToTruck(); following = truck; }

        if (Input.GetKeyDown(KeyCode.Alpha2)|| Input.GetKeyDown(KeyCode.Keypad2)) { SwapToBoat(); following = boat;}

        if (Input.GetKeyDown(KeyCode.Alpha3)|| Input.GetKeyDown(KeyCode.Keypad3)) { SwapToTank(); following = tank;}
        transform.position = following.transform.position + offset;

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
