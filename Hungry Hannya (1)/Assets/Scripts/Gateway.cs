using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : MonoBehaviour
{
    public float circlePos;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            collision.GetComponent<PlayerMovement>().GatewayEnter(circlePos);
        }
    }
}
