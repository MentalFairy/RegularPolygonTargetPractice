using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FitQuadToCamera : MonoBehaviour
{
    public Camera targetCamera; // Assign manually or leave null to auto-assign Main Camera
    public bool adjustOnUpdate = false; // Toggle for auto-resizing on resolution changes

    private Vector2 lastScreenSize;

    void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        FitQuad();
    }

    void Update()
    {
        if (adjustOnUpdate)
        {
            Vector2 currentScreenSize = new Vector2(Screen.width, Screen.height);
            if (currentScreenSize != lastScreenSize)
            {
                FitQuad();
                lastScreenSize = currentScreenSize;
            }
        }
    }

    private void FitQuad()
    {
        if (targetCamera == null) return;

        float quadHeight, quadWidth;

        if (targetCamera.orthographic)
        {
            // Orthographic: Quad height = 2 * camera size, width depends on aspect ratio
            quadHeight = targetCamera.orthographicSize * 2;
            quadWidth = quadHeight * targetCamera.aspect;
        }
        else
        {
            // Perspective: Calculate based on FOV and distance
            float distance = transform.position.z - targetCamera.transform.position.z;
            quadHeight = 2.0f * distance * Mathf.Tan(targetCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            quadWidth = quadHeight * targetCamera.aspect;
        }

        transform.localScale = new Vector3(quadWidth, quadHeight, 1);
    }
}
