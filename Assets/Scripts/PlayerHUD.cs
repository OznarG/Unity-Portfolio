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
        Debug.Log("EnteredFlash");
        healthFlash.color = new Color(255, 22, 0, 0);

        float t = 0;
        if(flashOn == false)
        {
            flashOn = true;
            while (t < duration)
            {
                t += Time.deltaTime;
                float a = Mathf.Lerp(1f, 0f, t / duration);
                healthFlash.color = new Color(255, 22, 0, t*10);
                yield return null;
            }
        }
        flashOn = false;

    }
    public void FLashScreen(float duration)
    {
        StartCoroutine(FlashRoutine(duration));
    }

    #endregion
    }
