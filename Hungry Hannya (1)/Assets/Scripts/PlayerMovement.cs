using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float centerOffset = 16f;
    float underSpeed = 5f;
    float overSpeed = .2f;
    float xLook = -1f;
    float yLook;
    public Rigidbody2D rb;
    public bool underground = true;
    public UIScript uIScript;
    public GameObject spriteObject;
    public Sprite swimSprite;
    public Sprite walkSprite;

    //public Animator animator;

    Vector2 underMovement;
    public float overMovement;

    void Update()
    {
        // Input
        underMovement.x = Input.GetAxisRaw("Horizontal");
        underMovement.y = Input.GetAxisRaw("Vertical");
        /*
        // Setting values for the animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        */
        if (underground == false)
        {
            return;
        }
        Vector3 lookAt = new Vector3(xLook, yLook);

        var dir = lookAt - transform.position;
        var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }

    // Calculating movement and moving the player
    private void FixedUpdate()
    {
        if (uIScript.IsPaused || uIScript.gameOver)
        {
            return;
        }
        if (underground)
        {
            rb.MovePosition(rb.position + underMovement * underSpeed * Time.fixedDeltaTime);
            if (underMovement.x != 0 && underMovement.x != 0)
            {
                xLook = transform.position.x + Mathf.Sin(underMovement.x * (Mathf.PI / 2));
                yLook = transform.position.y + Mathf.Sin(underMovement.y * (Mathf.PI / 2));
            }
            else if (underMovement.x != 0)
            {
                xLook = transform.position.x + Mathf.Sin(underMovement.x * (Mathf.PI / 2));
                yLook = transform.position.y;
            }
            else if (underMovement.y != 0)
            {
                xLook = transform.position.x;
                yLook = transform.position.y + Mathf.Sin(underMovement.y * (Mathf.PI / 2));
            }
        } else
        {
            var dir = transform.position - Vector3.zero;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            overMovement += Input.GetAxis("Horizontal") * Time.deltaTime * overSpeed;
            float xPos = Mathf.Sin(overMovement) * centerOffset;
            float yPos = Mathf.Cos(overMovement) * centerOffset;
            transform.position = new Vector3(xPos, yPos, -1f);
            if (Input.GetAxis("Horizontal") > 0.1)
            {
                spriteObject.GetComponent<SpriteRenderer>().flipX = true;
            } else if (Input.GetAxis("Horizontal") < -0.1)
            {
                spriteObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    public void GatewayEnter (float gatePosition)
    {
        if (underground)
        {
            overMovement = gatePosition - .15f;
            spriteObject.GetComponent<SpriteRenderer>().sprite = walkSprite;
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector2.zero, 3f);
            spriteObject.GetComponent<SpriteRenderer>().sprite = swimSprite;
            spriteObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        underground = !underground;
    }

    public void Eat (GameObject man)
    {
        if (underground)
        {
            return;
        }
        FindObjectOfType<HungerBar>().SetHunger(100f);
        uIScript.snacksEaten++;
        Destroy(man);

        ManMovement[] men = FindObjectsOfType<ManMovement>();
        int caughtBy = 0;
        for (int i = 0; i < men.Length; i++)
        {
            if (men[i].playerDistance < 6.5f)
            {
                caughtBy++;
            }
        }
        if (caughtBy >= 2)
        {
            uIScript.LoseGame(1);
        }
    }
}