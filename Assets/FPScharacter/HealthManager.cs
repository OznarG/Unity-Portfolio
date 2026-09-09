using UnityEngine;
public enum WoundTypes
{
    BITE, DEEP_lACERATION, LACERATION, DEEP_SCRATCH, SCRATCH 
}
public enum BodyParts
{
    HEAD, NECK, LEFT_LEG, RIGHT_LEG, UPPER_BODY, LEFT_ARM, RIGHT_ARM
}

public class HealthManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseEffect(WoundTypes type, BodyParts bodyPart)
    {
        Wound wound = gameObject.AddComponent<Wound>();
        WoundTypeEffect(type, wound);
        BodyPartEffect(bodyPart, wound);
    }
    public void BodyPartEffect(BodyParts bodyPart, Wound wound)
    {
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
    }
    public void WoundTypeEffect(WoundTypes woundType, Wound wound)
    {
        wound.woundType = woundType;
        switch (woundType)
        {
            case WoundTypes.BITE:
                wound.duration = 40;
                break;
            case WoundTypes.DEEP_lACERATION:
                wound.duration = 50;
                break;
            case WoundTypes.LACERATION:
                wound.duration = 30;
                break;
            case WoundTypes.DEEP_SCRATCH:
                wound.duration = 20;
                break;
            case WoundTypes.SCRATCH:
                wound.duration = 10;
                break;
            default:
                break;
        }
    }
    
}
