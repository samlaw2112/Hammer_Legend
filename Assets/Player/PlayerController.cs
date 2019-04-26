using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Scalar applied to calculation of player rotation from input drag.")]
    public float rotationSensitivity;
    [Tooltip("Speed that arrow keys move player (won't need this for real game).")]
    public float movementSpeed;

    private Vector3 dragStartPoint;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerIfArrowDown();
    }

    // Called when user starts a drag. Logs drag starting position
    public void LogDragStartPoint()
    {
        dragStartPoint = Input.mousePosition;
    }

    // Called during a drag. Updates rotation of the player
    public void RotatePlayer()
    {
        Vector3 dragOffset = Input.mousePosition - dragStartPoint;
        Vector3 rotation = new Vector3(0f, 0f, dragOffset.x * rotationSensitivity);
        transform.eulerAngles = rotation;
    }

    // Called at the end of a drag. Initiates hammer swing
    public void SwingHammer()
    {
        animator.SetTrigger("SwingTrigger");
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
            GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 0f);
        }
        else { return; };
    }


}
