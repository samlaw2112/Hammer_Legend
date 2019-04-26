using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Scalar applied to calculation of player rotation from input drag.")]
    public float rotationSensitivity;
    [Tooltip("Speed that arrow keys move player (won't need this for real game).")]
    public float movementSpeed;
    [Tooltip("Scalar applied to speed of first launch.")]
    public float firstLaunchSpeed;
    [Tooltip("Mass of player character (Active after start launch).")]
    public float playerMass;
    [Tooltip("Gravity scale of player character (Active after start launch).")]
    public float gravityScale;


    private Animator animator;
    private Rigidbody2D body;
   

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Debug.Log("Found body " + body);
        animator = GetComponent<Animator>();

        body.mass = playerMass;
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayerIfArrowDown();
    }

    // Updates rotation of the player
    public void RotatePlayer(Vector3 dragStartPoint, Vector3 dragCurrentPoint)
    {
        Vector3 dragOffset = dragCurrentPoint - dragStartPoint;
        Vector3 rotation = new Vector3(0f, 0f, dragOffset.x * rotationSensitivity);
        transform.eulerAngles = rotation;
    }

    //Initiates hammer swing
    public void SwingHammer()
    {
        animator.SetTrigger("SwingTrigger");
    }

    // Launches player based on angle and length of line drawn and turns on gravity
    public void InitialLaunch(Vector3 dragStartPoint, Vector3 dragCurrentPoint)
    {
        Vector3 dragOffset = dragCurrentPoint - dragStartPoint;
        body.velocity = dragOffset * -firstLaunchSpeed; // Launch in opposite direction to drag
        body.gravityScale = gravityScale;
    }


    // Move player with arrow keys (temporary only using for testing)
    void MovePlayerIfArrowDown()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-movementSpeed, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(movementSpeed, 0f);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0f, movementSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, -movementSpeed);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector3(0f, 0f);
        }
        else { return; };
    }

}
