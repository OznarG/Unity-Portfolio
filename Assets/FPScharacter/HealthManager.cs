using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//ENUMS to make everything easier to read in the code
public enum WoundTypes
{
    BITE, DEEP_lACERATION, LACERATION, DEEP_SCRATCH, SCRATCH 
}
public enum BodyParts
{
    HEAD, NECK, LEFT_LEG, RIGHT_LEG, UPPER_BODY, LEFT_ARM, RIGHT_ARM
}
//Created a Structure and added Serializable so we can see it in the inspector
[System.Serializable]
public struct WoundsMarks
{
    public Image laseration;
    public Image scratch;
    public Image bite;
    public Image bandage;
}
public class HealthManager : MonoBehaviour
{
    //References
    public static HealthManager instance;
    [SerializeField] WoundsMarks[] marks;
    public WoundMarkLinker[] woundMarkButtons;
    public List<Wound> woundsActive = new();
    public List<Wound> woundsToRemove = new();
    public Wound selectedWound;
    public Image selectionhighlight;
    public Button bandageButton;
    public Button removeBandageButton;
    public Button cleanWoundButton;
    public Button stichWoundButton;
    
    void Start()
    {
        //Created instance and add Lisener to healbutton
        //Sellected wound is set to null
        instance = this;
        selectedWound = null;
        bandageButton.onClick.AddListener(BandageWound);
        removeBandageButton.onClick.AddListener(RemoveBandage);
        cleanWoundButton.onClick.AddListener(CleanWound);
        stichWoundButton.onClick.AddListener(StitchWound);
    }
    private void Update()
    {
        foreach(Wound wound in woundsActive)
        {
            wound.CallEffect();
        }
        foreach (Wound wound in woundsToRemove)
        {
            Destroy(wound,1);
            woundsActive.Remove(wound);
            
        }
    }
    public void ChooseEffect(WoundTypes type, BodyParts bodyPart)
    {
        //It creates a wound variable and add it to the gameObject
        Wound wound = gameObject.AddComponent<Wound>();
        //Add Bodypart effect and wound type effect
        BodyPartEffect(bodyPart, wound);
        WoundTypeEffect(type, wound);
    }
    public void BodyPartEffect(BodyParts bodyPart, Wound wound)
    {
        //Grabs the passed wound and set bodypart equals to the one passed
        //based on the body part passsed add multiplayer to wound for the damage
        wound.bodyPart = bodyPart;       
        switch (bodyPart)
        {
            case BodyParts.HEAD:
                wound.multiplier = 1.2f;
                break;
            case BodyParts.NECK:
                wound.multiplier = 2.5f;
                break;
            case BodyParts.LEFT_LEG:
                wound.multiplier = 1.5f;
                break;
            case BodyParts.RIGHT_LEG:
                wound.multiplier = 1.5f;
                break;
            case BodyParts.UPPER_BODY:
                wound.multiplier = 1.0f;
                break;
            case BodyParts.LEFT_ARM:
                wound.multiplier = 1.0f;
                break;
            case BodyParts.RIGHT_ARM:
                wound.multiplier = 1.0f;
                break;
            default:
                break;
        }
        //wound marks is set the the marks list and choose the body part
        //based on the bodypart since they are on order 
        wound.woundsMark = marks[(int)bodyPart];
        //Set the wound generated to be controlled by the button on that area. 
        woundMarkButtons[(int)bodyPart].wound = wound;
    }
    public void WoundTypeEffect(WoundTypes woundType, Wound wound)
    {
        //set wound type to the passed type
        //then based on the type chooses the duration and marks
        wound.woundType = woundType;
        switch (woundType)
        {
            case WoundTypes.BITE:
                wound.duration = 40;
                wound.bleedingDuration = 40;
                wound.woundsMark.bite.gameObject.SetActive(true);
                break;
            case WoundTypes.DEEP_lACERATION:
                wound.duration = 50;
                wound.bleedingDuration = 50;
                wound.woundsMark.laseration.gameObject.SetActive(true);
                break;
            case WoundTypes.LACERATION:
                wound.duration = 30;
                wound.bleedingDuration = 30;
                wound.woundsMark.laseration.gameObject.SetActive(true);
                break;
            case WoundTypes.DEEP_SCRATCH:
                wound.duration = 20;
                wound.bleedingDuration = 20;
                wound.woundsMark.scratch.gameObject.SetActive(true);
                break;
            case WoundTypes.SCRATCH:
                wound.duration = 10;
                wound.bleedingDuration = 10;
                wound.woundsMark.scratch.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void BandageWound()
    {
        //Grabs Wound and put bandage on it
        selectedWound.UseBandage();
    }
    public void RemoveBandage()
    {
        selectedWound.RemoveBandage();
    }
    public void CleanWound()
    {
        selectedWound.CleanWound();
    }
    public void StitchWound()
    {
        selectedWound.StitchWound();
    }
}
