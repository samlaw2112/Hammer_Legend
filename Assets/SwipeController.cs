using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects swipes and performs appropriate action.
/// </summary>

public class SwipeController : MonoBehaviour
{
    private PlayerController player;
    private LaunchTrajectory launchTrajectory;
    private bool firstLaunch = true;
    private Vector3 dragStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming there will only ever be one player
        player = FindObjectOfType<PlayerController>();
        // And one launch trajectory
        launchTrajectory = FindObjectOfType<LaunchTrajectory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when user starts a drag
    public void StartDrag()
    {
        // Store start point of drag
        dragStartPoint = Input.mousePosition;
    }

    // Called during a drag
    public void UpdateDragPosition()
    {
        if (firstLaunch)
        {
            launchTrajectory.DrawLaunchTrajectory(dragStartPoint, Input.mousePosition);
        }
        else
        {
            player.RotatePlayer(dragStartPoint, Input.mousePosition);
        }
    }

    // Called at the end of a drag
    public void EndDrag()
    {
        // Do intitial launch if this is the first drag
        if (firstLaunch)
        {
            player.InitialLaunch(dragStartPoint, Input.mousePosition);
            launchTrajectory.DestroyLine();
            firstLaunch = false;
        }
        else
        {
            player.SwingHammer();
        }
    }
}
