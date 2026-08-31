using UnityEngine;

public class Pistol : FireArm
{
    
    public override void Reload()
    {
        currentMagazine = maxMagazine;
    }

    public override void Shot()
    {       
       Debug.DrawRay(cam.transform.position, cam.transform.forward * weaponRange, Color.red);
       anim.SetTrigger("Fire");
       RaycastHit hit;
       if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weaponRange))
       {          
           Debug.Log(hit.collider.tag.ToString());
           IDamage damageable = hit.collider.GetComponent<IDamage>();

            if (damageable != null)
            {
               damageable.TakeDamage(weaponDamage);
               Instantiate(GameManager.instance.weaponController.bulletHole[1], hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
               Instantiate(GameManager.instance.weaponController.bulletHole[0], hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
       currentMagazine--;      
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = GameManager.instance.mainCamera;  
        audioSource = GetComponent<AudioSource>();
        currentMagazine = maxMagazine;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayShot()
    {
        audioSource.PlayOneShot(shoots[0]);
        muzzleFlash.Play();
    }
    public void PlayReload()
    {
        audioSource.PlayOneShot(magIn);
    }
    public void TurnLightsOnOff()
    {
        muzzleLight.enabled = !muzzleLight.enabled;
    }
}
