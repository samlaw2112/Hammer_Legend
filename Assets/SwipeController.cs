﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects swipes and performs appropriate action.
/// </summary>

public class SwipeController : MonoBehaviour
{
    private Player player;
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
        }
    }

    // Call at start of press
    void UseJetPack()
    {
        if (!firstLaunch)
        {
            player.JetPackOn();
        }
    }

    // Call at start of press
    void StopJetPack()
    {
        if (!firstLaunch)
        {
            player.JetPackOff();
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
        StopJetPack();
    }

    public void SetNewPlayer(Player newPlayer)
    {
        player = newPlayer;
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
