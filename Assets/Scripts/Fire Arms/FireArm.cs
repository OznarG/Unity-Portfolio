using UnityEngine;

public abstract class FireArm : MonoBehaviour
{
    public Animator anim;
    public Camera cam;
    public float weaponRange;
    public float weaponDamage;
    public float fireRate;
    public float nextFireTime;
    public float currentMagazine;
    public float maxMagazine;

    public abstract void Shot();
    public abstract void Reload();
}
