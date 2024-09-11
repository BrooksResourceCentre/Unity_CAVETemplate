using UnityEngine;

public class CAVEMovementController : MonoBehaviour
{
    public Camera[] cameras; // Array of cameras for the walls and floor
    public GameObject cave; // Reference to the CAVE game object

    public Vector3 offset = new(0, 0, 0); // Offset to move the CAVE to the hit point
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        MoveCaveToClickPosition();
        RotateCave();
        CheckForQuit();
    }

    void MoveCaveToClickPosition()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            foreach (Camera cam in cameras)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    cave.transform.position = hit.point + offset; // Move the CAVE to the hit point
                    break; // Exit the loop once the CAVE is moved
                }
            }
        }
    }

    void RotateCave()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            cave.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime); // Rotate left
        }
        if (Input.GetKey(KeyCode.E))
        {
            cave.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Rotate right
        }
    }

    void CheckForQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); // Quit the application
        }
    }
}
