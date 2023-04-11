/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothTime = 0.3f; // The time it takes for the camera to catch up to the target
    public Vector3 offset = new Vector3(0f, 2f, -5f); // The initial position of the camera relative to the target

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // Calculate the target position of the camera
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
*/
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float smoothTime = 0.3f; // The time it takes for the camera to catch up to the target
    public Vector3 offset = new Vector3(0f, 2f, -5f); // The initial position of the camera relative to the target
    public float mouseSensitivity = 100f; // The sensitivity of the mouse movement
    public float pitchMin = -35f; // The minimum pitch angle of the camera
    public float pitchMax = 35f; // The maximum pitch angle of the camera

    private Vector3 velocity = Vector3.zero;
    private float yaw = 0f;
    private float pitch = 0f;

    private void LateUpdate()
    {
        // Calculate the target position of the camera
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate rotation angles based on mouse input
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        // Rotate camera and target object based on rotation angles
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        target.eulerAngles = new Vector3(0f, yaw, 0f);
    }
}
