using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("--- Component/references ---")]
    public FireArm[] fireArms = new FireArm[2] ;
    public FireArm selectedWeapon;
    private Camera cam;

    private bool canShoot;
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
        nextFireTime += Time.deltaTime;
        if(nextFireTime >= selectedWeapon.fireRate)
        {
            canShoot = true;
        }
    }
    public void Shoot()
    {
        GameManager.instance.fPSCharacterController.PlayerShot();

    }
    private void OnFire()
    {
        if(canShoot)
        {
            Shoot();
            nextFireTime = 0;
            canShoot= false;
        }      
    }
}
