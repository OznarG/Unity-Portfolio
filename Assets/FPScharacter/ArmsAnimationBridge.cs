using UnityEngine;

public class ArmsAnimationBridge : MonoBehaviour
{
    public void ArmFire()
    {
        GameManager.instance.fPSCharacterController.ShootWeapon();
    }
    public void IsShooting()
    {
        GameManager.instance.weaponController.canShoot = false;
        GameManager.instance.weaponController.isShooting = true;

    }

    public void DoneShooting()
    {
        GameManager.instance.weaponController.canShoot = true;

        GameManager.instance.weaponController.isShooting = false;
    }
}
