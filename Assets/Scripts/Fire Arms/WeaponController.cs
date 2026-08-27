using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class WeaponController : MonoBehaviour
{
    [Header("--- Component/references ---")]
    public FireArm[] fireArms = new FireArm[2] ;
    public FireArm selectedWeapon;
    private Camera cam;

    public bool canShoot;
    public bool isShooting;
    public float nextFireTime;

    private Ray ray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canShoot = true;
        cam = GameManager.instance.mainCamera;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shoot()
    {
        GameManager.instance.fPSCharacterController.PlayerShot();

    }
    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        if (canShoot)
        {
            Shoot();           
        }      
    }
    public void OnWeaponSwitch(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();

        if (value == 1) // key pressed
        {
            // Now check WHICH key was pressed
            string controlName = ctx.control.name;

            if (controlName == "1")
            {
                if(!isShooting)
                {
                    selectedWeapon.gameObject.SetActive(false);
                    selectedWeapon = fireArms[0];
                    selectedWeapon.gameObject.SetActive(true);
                }
            }
            else if (controlName == "2")
            {
                if (!isShooting)
                {
                    selectedWeapon.gameObject.SetActive(false);
                    selectedWeapon = fireArms[1];
                    selectedWeapon.gameObject.SetActive(true);
                }
            }
        }
    }
}
