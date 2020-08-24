using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
	  public static SpriteRenderer spriteRenderer;
    public static Sprite bathtub;
    void Awake()
    {
      spriteRenderer =  this.GetComponent<SpriteRenderer>();
      bathtub = (Instantiate(Resources.Load("colored_transparent_packed_492")) as GameObject).GetComponent<SpriteRenderer>().sprite;

   }


}
