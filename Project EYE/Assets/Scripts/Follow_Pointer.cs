using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Pointer : MonoBehaviour
{

    public GameObject myPlayer;

    void FixedUpdate()
    {
        Vector3 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        distance.Normalize();

        float rotationZ = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}
