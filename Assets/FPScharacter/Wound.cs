using System.Collections;
using Unity.AppUI.UI;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
//TODO: Add the bleeding to Update on health manager so it does not
//updates the timer time on a list of wounds
public class Wound : MonoBehaviour
{
    [Header("-- References/Component --")]
    public WoundTypes woundType;
    public BodyParts bodyPart;
    public WoundsMarks woundsMark;

    public float duration;
    public float bleedingDuration;
    public float multiplier;
    public bool bandaged;
    public bool healled;

    void Start()
    {      
        HealthManager.instance.woundsActive.Add(this);
    }
    public void CallEffect()
    {
        if(duration > 0)
        {
            if(!bandaged && bleedingDuration > 0)
            {
                GameManager.instance.characterStats.TakeDamage(0.25f * multiplier * Time.deltaTime);
            }           
            bleedingDuration -= Time.deltaTime;
            duration -= Time.deltaTime;
        }
        else
        {
            HealWound();
        }
    }
    public void HealWound()
    {
        
        switch (woundType)
        {
            case WoundTypes.BITE:
                woundsMark.bite.gameObject.SetActive(false);
                break;
            case WoundTypes.DEEP_lACERATION:
                woundsMark.laseration.gameObject.SetActive(false);
                break;
            case WoundTypes.LACERATION:
                woundsMark.laseration.gameObject.SetActive(false);
                break;
            case WoundTypes.DEEP_SCRATCH:
                woundsMark.scratch.gameObject.SetActive(false);
                break;
            case WoundTypes.SCRATCH:
                woundsMark.scratch.gameObject.SetActive(false);
                break;
            default:
                break;

                
        }
        healled = true;
        if(bandaged != true)
        {
            HealthManager.instance.woundsToRemove.Add(this);
        }
    }

    public void UseBandage()
    {
        //if the bandage is used the bleeding stop and the bandage on the wounds mark is set to on
        woundsMark.bandage.gameObject.SetActive(true);
        if(bandaged != true)
        {
            bandaged = true;
            GameManager.instance._playernventoryScript.RemoveItem("Bandage");
        }
        

    }
    public void RemoveBandage()
    {
        woundsMark.bandage.gameObject.SetActive(false);
        bandaged = false;
        if(healled == true)
        {
            HealthManager.instance.woundsToRemove.Add(this);
        }
    }
    public void SelectWound(GameObject highlight)
    {
        
        //Select this duh
        if(HealthManager.instance.selectedWound == this)
        {
            Debug.Log("Selected Inside");

            HealthManager.instance.selectedWound = null;
            HealthManager.instance.bandageButton.gameObject.SetActive(false);
            HealthManager.instance.removeBandageButton.gameObject.SetActive(false);
            highlight.SetActive(false);
        }
        else
        {
            Debug.Log("Selected not Inside");

            HealthManager.instance.selectedWound = this;

            HealthManager.instance.bandageButton.gameObject.SetActive(Contains("Bandage"));
            Debug.Log(GameManager.instance._playernventoryScript.itemsOnHand.ContainsKey("Bandage"));
            HealthManager.instance.removeBandageButton.gameObject.SetActive(true);
            highlight.SetActive(true);
            
        }

    }
    public bool Contains(string name)
    {
        if(GameManager.instance._playernventoryScript.itemsOnHand.ContainsKey(name))
        {
            if(GameManager.instance._playernventoryScript.itemsOnHand[name] > 0)
            {
                return true;
            }
        }
        return false;
    }
    public void CleanWound()
    {

    }
    public void StitchWound()
    {

    }
 
}
