using UnityEngine;

public class ArmsAnimationBridge : MonoBehaviour
{
    public void ArmFire()
    {
        GameManager.instance.fPSCharacterController.ShootWeapon();
    }
    public void ReloadWeapon()
    {
        GameManager.instance.fPSCharacterController.ReloadWeapon();
    }
    public void IsAnimating()
    {
        GameManager.instance.weaponController.canShoot = false;
        GameManager.instance.weaponController.isAnimating = true;

    }

    public void DoneAnimating()
    {
        GameManager.instance.weaponController.canShoot = true;

        GameManager.instance.weaponController.isAnimating = false;
    }
}
