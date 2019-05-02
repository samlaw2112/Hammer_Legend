using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchTrajectory : MonoBehaviour
{
    [Tooltip("Scalar applied to length of drawn launch trajectory.")]
    public float lineLength;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Called during drag for initial launch.
    // Updates line according to launch trajectory
    public void DrawLaunchTrajectory(Vector3 dragStartPoint, Vector3 dragCurrentPoint)
    {
        // 2 points - start and end
        Vector3[] points = new Vector3[2];
        // Start line at object position
        points[0] = transform.position;
        // Position end line using launch trajectory
        Vector3 offset = dragCurrentPoint - dragStartPoint;
        points[1] = transform.position - (offset * lineLength); // Draw trajectory in opposite direction of drag

        // Draw
        lineRenderer.SetPositions(points);
    }

    public void DestroyLine()
    {
        lineRenderer.enabled = false;
    }


}
