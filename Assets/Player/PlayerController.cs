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
    private CameraHandle cameraHandle;

    private void Awake()
    {
        swipeController = FindObjectOfType<SwipeController>();
        cameraHandle = FindObjectOfType<CameraHandle>();
        SpawnPlayer();
    }

    // Spawn a new player and ready for first launch
    public void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity) as GameObject;
        player.transform.SetParent(transform);
        cameraHandle.ResetGamePosition();
        cameraHandle.SetNewPlayer(player.GetComponent<Player>());
        swipeController.SetNewPlayer(player.GetComponent<Player>());
        swipeController.SetFirstLaunch();
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
