using UnityEngine;

[ExecuteAlways]
public class SplitScreenSetup : MonoBehaviour
{
    public Camera leftCamera;
    public Camera rightCamera;

    void Start()
    {
        if (leftCamera != null)
            leftCamera.rect = new Rect(0f, 0f, 0.5f, 1f); // Left half of screen

        if (rightCamera != null)
            rightCamera.rect = new Rect(0.5f, 0f, 0.5f, 1f); // Right half of screen
    }
}
