using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMovement : MonoBehaviour
{
    public bool isFollowing = false;
    float worldRadius = 15;
    float speed = .1f;
    public float moveTo;
    public float moveTimer;
    public float movement;
    public float playerDistance;

    float startX;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        MoveToNew();
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector2.Distance(gameObject.transform.position, FindObjectOfType<PlayerMovement>().transform.position);
        var dir = transform.position - Vector3.zero;
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);

        moveTimer -= Time.deltaTime;

        if (moveTo > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            movement += Time.deltaTime * speed;
        } else
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
            movement -= Time.deltaTime * speed;
        }

        if (moveTimer <= 0)
        {
            MoveToNew();
        }

        float xPos = Mathf.Sin(movement) * worldRadius;
        float yPos = Mathf.Cos(movement) * worldRadius;

        transform.position = new Vector3(xPos, yPos, 1f);
    }

    void MoveToNew ()
    {
        float speedAdjust = (1 / speed);
        float range = Random.Range(Mathf.PI / 2, Mathf.PI * 2);
        moveTo = Random.Range(-range, range);
        moveTimer = Mathf.Sqrt(Mathf.Pow(moveTo * speedAdjust, 2));

        if (moveTo > 0)
        {
        } else
        {
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            collision.GetComponent<PlayerMovement>().Eat(gameObject);
        }
    }
}