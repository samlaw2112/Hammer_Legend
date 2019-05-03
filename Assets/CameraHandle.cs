using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controls game movement, follows player
/// </summary>
public class CameraHandle : MonoBehaviour
{
    LevelController levelController;
    // Camera Follow Start is a game object in the inspector positioned at the location beyond which
    // the camera should follow the player
    Transform cameraFollowStart;
    Player player;
    Vector3 startPosition;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        cameraFollowStart = GameObject.Find("Camera Follow Start").GetComponent<Transform>();
        GetStartPosition();
        GetPlayer();
        GetInitialCameraOffset();
    }

    private void LateUpdate()
    {
        if (player.transform.position.x > cameraFollowStart.position.x)
        {
            // camera follows player (x dimension only)
            transform.position = new Vector3(player.transform.position.x + offset, 0, -10);
            Debug.Log("player position: " + player.transform.position.x);
            Debug.Log("camera position: " + transform.position.x);
        }
    }

    void GetInitialCameraOffset()
    {
        offset = transform.position.x - cameraFollowStart.position.x;
    }

    void GetPlayer()
    {
        player = levelController.GetPlayer(); ;
    }

    void GetStartPosition()
    {
        startPosition = transform.position;
        Debug.Log("Start position: " + startPosition);
    }

    public void ResetCamera()
    {
        // Not working because this gets called before (LevelController.Awake()) we can get the transform of the camera
        transform.position = startPosition;
        Debug.Log("Resetting camera to: " + transform.position);
        GetPlayer();
    }

}
