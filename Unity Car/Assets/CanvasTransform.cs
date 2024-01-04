using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CanvasTransform  : MonoBehaviour
{
    public Camera targetCamera;
    public float distanceFromCamera = 2.0f;
    public Vector2 offset; // Offset in X (left-right) and Y (up-down)

    void Update()
    {
        if (targetCamera == null) return;

        // Make the Canvas face the camera
        transform.LookAt(transform.position + targetCamera.transform.rotation * Vector3.forward,
            targetCamera.transform.rotation * Vector3.up);

        // Calculate the offset position
        Vector3 offsetPosition = targetCamera.transform.forward * distanceFromCamera;
        offsetPosition += targetCamera.transform.right * offset.x; // Add left-right offset
        offsetPosition -= targetCamera.transform.up * offset.y;    // Add up-down offset

        // Adjust the Canvas position with offset
        transform.position = targetCamera.transform.position + offsetPosition;
    }
}
