using UnityEngine;

public abstract class FireArm : MonoBehaviour
{
    public Animator anim;
    public Camera cam;
    public AudioSource audioSource;
    public ParticleSystem muzzleFlash;

    public float weaponRange;
    public float weaponDamage;
    public float fireRate;
    public float nextFireTime;
    public float currentMagazine;
    public float maxMagazine;

    public AudioClip magIn;
    public AudioClip[] shoots;
    public AudioClip noBullets;

    public Light muzzleLight;
    public abstract void Shot();
    public abstract void Reload();
}
