﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Positioned and level start (player spawn location). Responsible for keeping track of various
/// game objects and handles level events such as player death and respawn
/// </summary>
public class LevelController : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject player;
    private SwipeController swipeController;
    private CameraHandle cameraHandle;
    private bool firstSpawn = true;

    private void Awake()
    {
        swipeController = FindObjectOfType<SwipeController>();
        cameraHandle = FindObjectOfType<CameraHandle>();
        SpawnPlayer();
    }

    // Spawn a new player, ready for first launch and reset camera position
    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        player.transform.SetParent(transform);
        swipeController.SetNewPlayer(player.GetComponent<Player>());
        swipeController.SetFirstLaunch();
        // Only need to reset the camera for respawns, not on initial spawn
        if (firstSpawn) { firstSpawn = false;
        } else { cameraHandle.ResetCamera(); }
    }

    // Destroy player and spawn a new one
    public void DestroyPlayer()
    {
        Destroy(player.gameObject);
        SpawnPlayer();
    }

    public Player GetPlayer()
    {
        return player.GetComponent<Player>();
    }

}