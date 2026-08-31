using UnityEngine;

public class Pistol : FireArm
{
    public override void Shot()
    {       
       //Draw a red line on the shoot direction to see it in the scene
       Debug.DrawRay(cam.transform.position, cam.transform.forward * weaponRange, Color.red);
       //Start the gun fire animation
       anim.SetTrigger("Fire");
       //This stores information of the collider hit by a ray
       RaycastHit hit;
       //Create a ray at the cam position, looking forward, and store the info in hit, with the range of weapon range
       if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weaponRange))
       {     
           //Thistakes the tags of the object in hit and display it in the debug console
           Debug.Log(hit.collider.tag.ToString());
           //Get interface IDamage from the object in hit
           IDamage damageable = hit.collider.GetComponent<IDamage>();
           //If it hits something that can take damage, deal damage and create the bullet hit vfx
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
       //Decrease one bullet from gun
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
    #region ---ANIMATION HELPER/EVENTS---
    //Reload the Pistol
    public override void Reload()
    {
        currentMagazine = maxMagazine;
    }
    //Play the Shot Sound and particle, this is called in gunfire event
    public void PlayShot()
    {
        audioSource.PlayOneShot(shoots[0]);
        muzzleFlash.Play();
    }
    //This plays reload sound when an event calls it 
    public void PlayReload()
    {
        audioSource.PlayOneShot(magIn);
    }
    //This turns the lighs on or off and is called in an animation event
    public void TurnLightsOnOff()
    {
        muzzleLight.enabled = !muzzleLight.enabled;
    }
    #endregion
}
