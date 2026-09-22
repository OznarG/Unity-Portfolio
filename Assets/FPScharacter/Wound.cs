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
        //Add the script to the lis as soon as is created
        HealthManager.instance.woundsActive.Add(this);
    }
    public void CallEffect()
    {
        //if the duration is not over go in
        //if is not bandaged or bleeding still on. apply damage then reduce bleding and duration time
        if(duration > 0)
        {
            if(!bandaged && bleedingDuration > 0)
            {
                GameManager.instance.characterStats.TakeDamage(0.25f * multiplier * Time.deltaTime);
            }           
            bleedingDuration -= Time.deltaTime;
            duration -= Time.deltaTime;
        }
        //if duration is over, heal the wound
        else
        {
            HealWound();
        }
    }
    public void HealWound()
    {
        //Check the active wound and set it off
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
        //Set healed to true and if is not bandage place it on the deletion list
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
        //if is not bandaged then put bandage on and remove a bandage from inventory
        if(bandaged != true)
        {
            bandaged = true;
            GameManager.instance._playernventoryScript.RemoveItem("Bandage");
        }
    }
    public void RemoveBandage()
    {
        //remove bandage by turningi t off and if is healed then remove the wound from list
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
        //if is equals then go in and make it null and unselect it
        //because if this function was called when it was selected so unselect
        if(HealthManager.instance.selectedWound == this)
        {
            HealthManager.instance.selectedWound = null;
            HealthManager.instance.bandageButton.gameObject.SetActive(false);
            HealthManager.instance.removeBandageButton.gameObject.SetActive(false);
            highlight.SetActive(false);
        }
        else
        {
            //if is not eual, set it to this 
            //if it has bandage then put bandage button on, same with remove bandage
            HealthManager.instance.selectedWound = this;
            HealthManager.instance.bandageButton.gameObject.SetActive(Contains("Bandage"));
            HealthManager.instance.removeBandageButton.gameObject.SetActive(true);
            highlight.SetActive(true);
            
        }

    }
    public bool Contains(string name)
    {
        //check if the inventory has this items on it and how many
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
