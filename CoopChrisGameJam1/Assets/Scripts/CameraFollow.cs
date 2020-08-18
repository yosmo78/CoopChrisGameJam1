using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    public Vector3 offset = new Vector3(0f, 0f, 0f);

    void LateUpdate()
    {

        transform.position = player.position + offset;

    }
}
