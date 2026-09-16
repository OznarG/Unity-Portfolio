using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//TODO: Add the bleeding to Update on health manager so it does not
//updates the timer time on a list of wounds
public class Wound : MonoBehaviour
{
    [Header("-- References/Component --")]
    private Coroutine bleedRoutine;
    public WoundTypes woundType;
    public BodyParts bodyPart;
    public WoundsMarks woundsMark;

    public float duration;
    public float multiplier;
    public bool bleedTemp = false;
    public bool bleedStopped = false;

    void Start()
    {      
        //Starts bleeding
        StartBleeding();
    }
    IEnumerator BleedEffect()
    {
        //Set time
        float timer = 0f;
        //check for condition
        while (timer < duration && !bleedStopped)
        {
            //if still bleeding it add to timer
            timer += Time.deltaTime;
            //Add damage to the player as bleeding
            GameManager.instance.characterStats.TakeDamage(0.25f * multiplier * Time.deltaTime);
            //If the bleeding is temporal and the timer is bellow the time the bleeing stops
            if(timer < duration && bleedTemp)
            {
                bleedStopped = true;
            }
            yield return null; 
        }
        //if the timer goes down the function works
        StopBleeding();
    }
    public void StartBleeding()
    {
        //if bleeding is not on it will turn on one
        if (bleedRoutine != null)
            StopCoroutine(bleedRoutine);
        bleedRoutine = StartCoroutine(BleedEffect());
    }

    public void StopBleeding()
    {
        //if the couroutine is not null then stop it and set it to null
        if (bleedRoutine != null)
        {
            StopCoroutine(bleedRoutine);
            bleedRoutine = null;
        }
    }

    void OnDestroy()
    {
        //if destroy the wound then thcouroutine stops too
        StopBleeding();
    }

    public void UseBandage()
    {
        //if the bandage is used the bleeding stop and the bandage on the wounds mark is set to on
        woundsMark.bandage.gameObject.SetActive(true);
        StopBleeding();
    }
    public void SelectWound()
    {
        //Select this duh
        HealthManager.instance.selectedWound = this;
    }
}
