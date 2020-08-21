using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryText : MonoBehaviour
{
    public Text text;

	public Vector3 offset = new Vector3(0f, 0.19f, 0f);
	
    // Update is called once per frame
    void Update()
    {
        transform.position = CameraFollow.following.transform.position + offset;
    }
}
