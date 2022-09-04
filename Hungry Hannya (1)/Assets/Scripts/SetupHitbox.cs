using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupHitbox : MonoBehaviour
{
    EdgeCollider2D collider;
    Vector2[] circlePoints;
    int pointCount = 50;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<EdgeCollider2D>();
        circlePoints = new Vector2[pointCount];

        for (int i = 0; i < circlePoints.Length-1; i++)
        {
            float pointX = Mathf.Sin(2 * Mathf.PI / (pointCount - 1) * i) / 2;
            float pointY = Mathf.Cos(2 * Mathf.PI / (pointCount - 1) * i) / 2;
            circlePoints[i] = new Vector2(pointX, pointY);
            //Debug.Log(i + ": x= " + pointX + "| y= " + pointY);
        }
        circlePoints[circlePoints.Length-1] = circlePoints[0];
        collider.points = circlePoints;
    }
}
