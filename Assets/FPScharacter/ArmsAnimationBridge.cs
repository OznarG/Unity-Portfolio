using UnityEngine;

public class ArmsAnimationBridge : MonoBehaviour
{
    //This are Events called in arm, sicne I have all my script in a separate object from the animator's object
    //I had to create a helper to put on the animator's object
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
