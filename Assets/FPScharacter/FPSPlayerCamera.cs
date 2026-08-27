using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerCamera : MonoBehaviour
{
    //Components and references
    public Transform camTransform;

    //variables to adjust camera movement
    public float mouseSensitivity;
    private float xRotation = 0f;
    [SerializeField] float maxUplook;
    [SerializeField] float maxDownlook;
    private Vector2 lookInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Locks curson on Place and Turn off visibility
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MouseLook();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        //Every Time the mouse moves this is called
        lookInput = ctx.ReadValue<Vector2>();
    }

    void MouseLook()
    {
        //Stores values for mouse moving Horizontally and Vertically
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        //Rotates camera up or down
        xRotation -= mouseY;
        //Clamps movement so it has a limit up and down
        xRotation = Mathf.Clamp(xRotation, -maxDownlook, maxUplook);
        //Apply rotation
        camTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    public void ShakeCamera()
    {

    }
}
