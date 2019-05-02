using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controls game movement, follows player and resets after player death
/// </summary>
public class CameraHandle : MonoBehaviour
{
    PlayerController playerController;
    Player player;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        GetInitialCameraOffset();
    }

    private void FixedUpdate()
    {
        if (player.GetInAir())
        {
            transform.position = new Vector2(player.transform.position.x + offset, 0f);
            Debug.Log("player position: " + player.transform.position.x);
            Debug.Log("camera position: " + transform.position.x);
        }
    }

    void GetInitialCameraOffset()
    {
        offset = transform.position.x - player.transform.position.x;
        Debug.Log("Initial camera offset: " + offset);
    }

    public void SetNewPlayer(Player newPlayer)
    {
        player = newPlayer;
    }

    public void ResetGamePosition()
    {
        transform.position = new Vector2(0f, 0f);
    }
}
