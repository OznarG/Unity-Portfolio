using UnityEngine;

public class Pistol : FireArm
{
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
                damageable.TakeDamage(weaponDamage);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = GameManager.instance.mainCamera;       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
