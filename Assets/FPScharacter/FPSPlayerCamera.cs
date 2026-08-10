using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerCamera : MonoBehaviour
{
    public float mouseSensitivity;
    public Transform camTransform;

    private float xRotation = 0f;
    private Vector2 lookInput;

    [SerializeField] float maxUplook;
    [SerializeField] float maxDownlook;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void MouseLook()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxDownlook, maxUplook);

        camTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
