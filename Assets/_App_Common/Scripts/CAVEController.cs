using UnityEngine;

public class CAVEController : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Reference to the cameras in the CAVE")]
    [SerializeField] private Camera[] cameras;

    [Tooltip("Reference to the CAVE game object")]
    [SerializeField] private  GameObject cave;



    [Header("Settings: Movement")]
    [SerializeField] private float movementSpeed = 10f; // Speed of movement
    [SerializeField] private  float rotationSpeed = 100f; // Speed of rotation




    [Header("Settings: touch Actions")]

    [Tooltip("Select the touch action to perform")]
    [SerializeField] private TouchType selectedTouchType = TouchType.None;

    [Tooltip("Offset to move the CAVE to after the hit point")]
    [SerializeField] private  Vector3 teleportOffset = new(0, 0, 0); // Offset to move the CAVE to the hit point
    




    [Tooltip("The touch actions available to perform")]
    private enum TouchType { None, Teleport, SpawnSphere};



    void Update()
    {
        // Touch Input
        switch (selectedTouchType)
        {
            case TouchType.Teleport:
                MoveCaveToClickPosition();
                break;
            case TouchType.SpawnSphere:
                InstantiateSphereAtClickPosition();
                break;
            default:
                break;
        }

        // Keyboard Input
        TryContiniousMove();
        TryRotate();
        TryQuit();
    }


    #region Touch Actions
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
                    cave.transform.position = hit.point + teleportOffset; // Move the CAVE to the hit point
                    break; // Exit the loop once the CAVE is moved
                }
            }
        }
    }

    void InstantiateSphereAtClickPosition()
    {
        if (Input.GetMouseButtonDown(1)) // Check for right mouse button click
        {
            foreach (Camera cam in cameras)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Create a sphere
                    sphere.transform.position = hit.point; // Move the sphere to the hit point
                    break; // Exit the loop once the sphere is created
                }
            }
        }
    }
    #endregion


    #region Keyboard Actions
    void TryContiniousMove()
    {
        if (Input.GetKey(KeyCode.W))
            cave.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime); // Move forward

        if (Input.GetKey(KeyCode.S))
            cave.transform.Translate(Vector3.back * movementSpeed * Time.deltaTime); // Move backward

        if (Input.GetKey(KeyCode.A))
            cave.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime); // Move left

        if (Input.GetKey(KeyCode.D))
            cave.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime); // Move right
    }

    void TryRotate()
    {
        if (Input.GetKey(KeyCode.Q))
            cave.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime); // Rotate left

        if (Input.GetKey(KeyCode.E))
            cave.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Rotate right
    }

    void TryQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(); // Quit the application
    }
    #endregion

}
