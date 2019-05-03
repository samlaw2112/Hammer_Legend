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
        GetInitialCameraOffset();
    }

    private void LateUpdate()
    {
        if (player.transform.position.x > cameraFollowStart.position.x)
        {
            // camera follows player (x dimension only)
            transform.position = new Vector3(player.transform.position.x + offset, 0, -10);
        }
    }

    void GetInitialCameraOffset()
    {
        offset = transform.position.x - cameraFollowStart.position.x;
    }

    void GetStartPosition()
    {
        startPosition = transform.position;
    }

    public void ResetCamera()
    {
        transform.position = startPosition;
    }

    public void SetPlayer(Player input)
    {
        player = input;
    }

}
