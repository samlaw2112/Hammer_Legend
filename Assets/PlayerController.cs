using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Scalar applied to calculation of player rotation from input drag.")]
    public float rotationSensitivity;

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
}
