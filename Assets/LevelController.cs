﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Positioned at level start (player spawn location). Responsible for keeping track of various
/// game objects and handles level events such as player death and respawn
/// </summary>
public class LevelController : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject player;
    private SwipeController swipeController;
    private CameraHandle cameraHandle;
    private PlatformSpawner platformSpawner;
    private bool firstSpawn = true;

    private void Awake()
    { 
        // Asuming only one of each of the following
        swipeController = FindObjectOfType<SwipeController>();
        cameraHandle = FindObjectOfType<CameraHandle>();
        platformSpawner = FindObjectOfType<PlatformSpawner>();
    }

    private void Start()
    {
        SpawnPlayer();
    }

    // Spawn a new player, ready for first launch and reset camera position
    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        player.transform.SetParent(transform);
        // Tell other game objects about new player
        swipeController.SetNewPlayer(GetPlayer());
        swipeController.SetFirstLaunch();
        cameraHandle.SetPlayer(GetPlayer());
        platformSpawner.SetPlayer(GetPlayer());
        // Only need to reset the camera for respawns, not on initial spawn
        if (firstSpawn)
        {
            firstSpawn = false;
        } else
        {
            cameraHandle.ResetCamera();
        }
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
