using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClouds : MonoBehaviour
{
    float rotation;
    // Update is called once per frame
    void Update()
    {
        rotation += Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(-rotation, Vector3.forward);
    }
}
