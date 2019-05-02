using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Responsible for keeping track of, spawning and destroying player.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject player;
    private SwipeController swipeController;

    private void Start()
    {
        swipeController = FindObjectOfType<SwipeController>();
        SpawnPlayer();
    }

    // Spawn a new player and ready for first launch
    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        player.transform.SetParent(transform);
        swipeController.SetNewPlayer(player.GetComponent<Player>());
        swipeController.SetFirstLaunch();
    }

    // Destroy player and spawn a new one
    public void DestroyPlayer()
    {
        Destroy(player.gameObject);
        SpawnPlayer();
    }

}
