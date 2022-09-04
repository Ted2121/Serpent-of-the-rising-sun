using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour
{
    public GameObject[] trailObjects;

    // Update is called once per frame
    void Update()
    {
        //float keepDistance = .75f;
        for (int i = 1; i < trailObjects.Length; i++)
        {
            float pow = 5f;
            float division = 100f;

            float distance = Vector2.Distance(trailObjects[i-1].transform.position, trailObjects[i].transform.position);
            trailObjects[i].transform.position = Vector2.MoveTowards(trailObjects[i].transform.position, trailObjects[i - 1].transform.position, 
                Mathf.Pow(distance, pow) / division);
            var dir = trailObjects[i - 1].transform.position - trailObjects[i].transform.position;
            var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            trailObjects[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
    }
}
