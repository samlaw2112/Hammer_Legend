using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects swipes and performs appropriate action.
/// </summary>

public class SwipeController : MonoBehaviour
{
    private Player player;
    private JetPack jetPack;
    private LaunchTrajectory launchTrajectory;
    private bool firstLaunch, isDown = false;
    private Vector3 dragStartPoint;

    // Update is called once per frame
    void FixedUpdate()
    {
        // If pointer is down
        if (isDown)
        {
            UpdateDragPosition();
            UseJetPack();
        }
    }

    // Called when user starts a drag
    void StartDrag()
    {
        // Store start point of drag
        dragStartPoint = Input.mousePosition;

        // Tell jet pack boost has just started (not on first launch)
        if (!firstLaunch)
        {
            jetPack.SetBoostStartTime();
        }
    }

    // Called during a drag
    void UpdateDragPosition()
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
    void EndDrag()
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
            StopJetPack();
        }
    }

    // Call at start of press
    void UseJetPack()
    {
        if (!firstLaunch)
        {
            jetPack.JetPackOn();
        }
    }

    // Call at end of press
    void StopJetPack()
    {
        if (!firstLaunch)
        {
            jetPack.JetPackOff();
        }
    }

    // Called by event trigger
    public void PointerDown()
    {
        // If pointer wasn't already down, start down events
        if (!isDown)
        {
            StartDrag();
            isDown = true;
        }
    }

    // Called by event trigger
    public void PointerUp()
    {
        isDown = false;
        EndDrag();
    }

    // Side effect gets the new player's jet pack also
    public void SetNewPlayer(Player newPlayer)
    {
        player = newPlayer;
        jetPack = newPlayer.GetComponent<JetPack>();
    }

    public void SetFirstLaunch ()
    {
        // Find launch tragectory on player
        launchTrajectory = player.GetComponentInChildren<LaunchTrajectory>();
        firstLaunch = true;
    }

    public bool GetFirstLaunch()
    {
        return firstLaunch;
    }
}
