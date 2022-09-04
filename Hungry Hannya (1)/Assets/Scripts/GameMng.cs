using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public GameObject manPrefab;
    public GameObject gatewayPrefab;
    int gatewaySpawns = 6;
    float manSpawnTimer = 10f;
    float worldRadius = 15;
    Vector3[] gatewayPosition;

    // Start is called before the first frame update
    public void Setup()
    {
        gatewayPosition = new Vector3[gatewaySpawns];

        SpawnMen(5);

        for (int i = 0; i < gatewayPosition.Length - 1; i++)
        {
            float pointX = Mathf.Sin(2 * Mathf.PI / (gatewaySpawns - 1) * i) * worldRadius;
            float pointY = Mathf.Cos(2 * Mathf.PI / (gatewaySpawns - 1) * i) * worldRadius;
            gatewayPosition[i] = new Vector3(pointX, pointY, -5f);

            var dir = transform.position - Vector3.zero;
            var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.back);
            GameObject gate = Instantiate(gatewayPrefab, gatewayPosition[i], rot);
            gate.GetComponent<Gateway>().circlePos = 2 * Mathf.PI / (gatewaySpawns - 1) * i;
            //Debug.Log(i + ": x= " + pointX + "| y= " + pointY);
        }
    }

    void SpawnMen (int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            float xPos = Random.Range(0, Mathf.PI * 2);
            GameObject man = Instantiate(manPrefab, new Vector3(0, 0, 15f), Quaternion.identity);
            man.GetComponent<ManMovement>().movement += Random.Range(-Mathf.PI, Mathf.PI);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<UIScript>().IsPaused)
        {
            return;
        }
        manSpawnTimer -= Time.deltaTime;
        if (manSpawnTimer <= 0)
        {
            SpawnMen(1);
            manSpawnTimer = 10f;
        }
    }
}
