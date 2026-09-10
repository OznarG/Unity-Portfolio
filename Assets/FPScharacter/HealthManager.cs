using UnityEngine;
using UnityEngine.UI;
public enum WoundTypes
{
    BITE, DEEP_lACERATION, LACERATION, DEEP_SCRATCH, SCRATCH 
}
public enum BodyParts
{
    HEAD, NECK, LEFT_LEG, RIGHT_LEG, UPPER_BODY, LEFT_ARM, RIGHT_ARM
}
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
    public static HealthManager instance;
    [SerializeField] WoundsMarks[] marks;
    public WoundMarkLinker[] woundMarkButtons;
    public Wound selectedWound;
    public Image selectionhighlight;
    public Button healButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        selectedWound = null;
        healButton.onClick.AddListener(BandageWound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseEffect(WoundTypes type, BodyParts bodyPart)
    {
        Wound wound = gameObject.AddComponent<Wound>();
        BodyPartEffect(bodyPart, wound);
        WoundTypeEffect(type, wound);
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
        wound.woundsMark = marks[(int)bodyPart];
        woundMarkButtons[(int)bodyPart].wound = wound;
    }
    public void WoundTypeEffect(WoundTypes woundType, Wound wound)
    {
        wound.woundType = woundType;
        switch (woundType)
        {
            case WoundTypes.BITE:
                wound.duration = 40;
                wound.woundsMark.bite.gameObject.SetActive(true);
                break;
            case WoundTypes.DEEP_lACERATION:
                wound.duration = 50;
                wound.woundsMark.laseration.gameObject.SetActive(true);
                break;
            case WoundTypes.LACERATION:
                wound.duration = 30;
                wound.woundsMark.laseration.gameObject.SetActive(true);
                break;
            case WoundTypes.DEEP_SCRATCH:
                wound.duration = 20;
                wound.woundsMark.scratch.gameObject.SetActive(true);
                break;
            case WoundTypes.SCRATCH:
                wound.duration = 10;
                wound.woundsMark.scratch.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
    
    public void BandageWound()
    {
        selectedWound.UseBandage();
    }
}
