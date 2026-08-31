using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class WeaponController : MonoBehaviour
{
    //Components Like fire arms and other usefull and needed references/variables
    [Header("--- Component/references ---")]
    public FireArm[] fireArms = new FireArm[2] ;
    public FireArm selectedWeapon;
    public GameObject[] bulletHole;
    private Camera cam;


    public bool canShoot;
    public bool isAnimating;
    public float nextFireTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canShoot = true;
        cam = GameManager.instance.mainCamera;
    }

    public void Shoot()
    {
        //It starts the player shot animation that then calls the weapon fire animation through an event
        GameManager.instance.fPSCharacterController.PlayerShot();
    }
    public void OnFire(InputAction.CallbackContext ctx)
    {
        //When the fire Button is pressed check if can shoot and has bullet and then Shot
        //If not check if is because of bullet and play the noBullets sound
        if (!ctx.performed) return;
        if (canShoot && selectedWeapon.currentMagazine > 0)
        {
            Shoot();           
        }      
        else if(selectedWeapon.currentMagazine <= 0)
        {
            selectedWeapon.audioSource.PlayOneShot(selectedWeapon.noBullets);
        }
    }
    public void OnReload(InputAction.CallbackContext ctx)
    {
        //CHeck if is animating and if is not then interupt and call player reload
        if (!ctx.performed) return;
        if (!isAnimating)
        {
            GameManager.instance.fPSCharacterController.StartPlayerReload();
        }
    }
    public void OnWeaponSwitch(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        //Check the key pressed and choose which weapon is under that key then set the other one off
        if (value == 1) 
        {
            
            string controlName = ctx.control.name;

            if (controlName == "1")
            {
                if(!isAnimating)
                {
                    selectedWeapon.gameObject.SetActive(false);
                    selectedWeapon = fireArms[0];
                    selectedWeapon.gameObject.SetActive(true);
                }
            }
            else if (controlName == "2")
            {
                if (!isAnimating)
                {
                    selectedWeapon.gameObject.SetActive(false);
                    selectedWeapon = fireArms[1];
                    selectedWeapon.gameObject.SetActive(true);
                }
            }
        }
    }
}
