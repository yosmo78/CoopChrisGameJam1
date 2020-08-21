using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
	public static SpriteRenderer[] spriteRenderer;
    public static Sprite emptyTruckBack;
    public static Sprite emptyTruckFront;
    public static Sprite fullTruckBack;
    public static Sprite fullTruckFront;
    void Awake()
    {
       spriteRenderer =  this.GetComponentsInChildren<SpriteRenderer>();

       fullTruckFront = (Instantiate(Resources.Load("colored_transparent_packed_971")) as GameObject).GetComponent<SpriteRenderer>().sprite;
       fullTruckBack = (Instantiate(Resources.Load("colored_transparent_packed_972")) as GameObject).GetComponent<SpriteRenderer>().sprite;
		emptyTruckBack = (Instantiate(Resources.Load("colored_transparent_packed_924")) as GameObject).GetComponent<SpriteRenderer>().sprite;
    	emptyTruckFront = (Instantiate(Resources.Load("colored_transparent_packed_923")) as GameObject).GetComponent<SpriteRenderer>().sprite;

   }


}
