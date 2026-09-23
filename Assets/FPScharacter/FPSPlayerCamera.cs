using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngineInternal;

public class FPSPlayerCamera : MonoBehaviour
{
    //Components and references
    public Transform camTransform;
    public GameObject objectLookingAt;
    public GameObject objectLookingAtStored;
    public Camera cam;


    //variables to adjust camera movement
    public float mouseSensitivity;
    private float xRotation = 0f;
    [SerializeField] float maxUplook;
    [SerializeField] float maxDownlook;
    [SerializeField] float rangeInterator;
    private Vector2 lookInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Locks curson on Place and Turn off visibility
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MouseLook();
        lookingAt();
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
    public void lookingAt()
    {
        RaycastHit hit;
        //Create a ray at the cam position, looking forward, and store the info in hit, with the range of weapon range
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rangeInterator))
        {
            //Thistakes the tags of the object in hit and display it in the debug console
            Debug.Log(hit.collider.tag.ToString());
            //Get interface IDamage from the object in hit
            Iinteractor interactor = hit.collider.GetComponent<Iinteractor>();
            //If it hits something that can take damage, deal damage and create the bullet hit vfx
            if (interactor != null)
            {
                // damageable.TakeDamage(weaponDamage);
                //Instantiate(GameManager.instance.weaponController.bulletHole[0], hit.point, Quaternion.LookRotation(hit.normal));            
                objectLookingAt = hit.collider.gameObject;
                objectLookingAtStored = objectLookingAt;
                interactor.ReadyToInteract();               
            }
            else
            {
                if(objectLookingAt != null)
                {
                    objectLookingAt.GetComponent<Iinteractor>().StopInteraction();
                }
                //Instantiate(GameManager.instance.weaponController.bulletHole[0], hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        else
        {
            if (objectLookingAtStored != null)
            {
                objectLookingAtStored.GetComponent<Iinteractor>().StopInteraction();
            }
            //Instantiate(GameManager.instance.weaponController.bulletHole[0], hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        Iinteractor interactor = objectLookingAt.GetComponent<Iinteractor>();
        if (interactor != null)
        {
            interactor.Interact();
        }
    }
}
