using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
	public const int BREAKING_VELOCITY = 2;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.relativeVelocity.magnitude > BREAKING_VELOCITY)
        	Debug.Log("Over 2!");
    }
}
