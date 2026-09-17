using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public enum HUD_BAR
{
    HEALTHBAR, VIRUSLOADBAR, STAMINABAR, AMMOBAR
}
public class PlayerHUD : MonoBehaviour
{
    
    [Header("-- Health Bar Area --")]
    public Image healthBar;
    public Image virusLoadBar;
    public Image staminaBar;
    [Header("-- Weapon HUD --")]
    public Image equiptWeapon;
    public Image ammoBar;
    public FireArm fireArm;
    [Header("--- Flashers ---")]
    public Image healthFlash;
    public bool flashOn;

    #region UPDATE METHODS
    //Chooses what bar to update and calculate based on inputs 
    public void UpdateBar(HUD_BAR barType, float min, float max)
    {
        switch (barType)
        {
            case HUD_BAR.HEALTHBAR:
                healthBar.fillAmount = min/max;
                break;
            case HUD_BAR.VIRUSLOADBAR:
                virusLoadBar.fillAmount = min/max;
                break;
            case HUD_BAR.STAMINABAR:
                staminaBar.fillAmount = min/max;
                break;
            case HUD_BAR.AMMOBAR:
                ammoBar.fillAmount = min/max;
                break;
            default:
                break;
        }
    }
    #endregion
    #region ACTION METHODS
    IEnumerator FlashRoutine(float duration)
    {
        
        Color tempC = healthBar.color;
        if(flashOn == false)
        {
            Debug.Log("EnteredFlash");
            float t = 0;
            flashOn = true;
            while (t < duration)
            {
                t += Time.deltaTime;
                Debug.Log(t);
                float a = +10 * Time.deltaTime;
                healthFlash.color = new Color(tempC.r, tempC.g, tempC.b, a);
                yield return null;
            }
            healthFlash.color = new Color(tempC.r, tempC.g, tempC.b, 0);
            flashOn = false;
        }
        

    }
    public void FLashScreen(float duration)
    {
        StartCoroutine(FlashRoutine(duration));
    }

    #endregion
    }
