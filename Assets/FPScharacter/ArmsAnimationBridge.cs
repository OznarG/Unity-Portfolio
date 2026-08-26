using UnityEngine;

public class ArmsAnimationBridge : MonoBehaviour
{
    public void ArmFire()
    {
        GameManager.instance.fPSCharacterController.ShootWeapon();
    }
}
