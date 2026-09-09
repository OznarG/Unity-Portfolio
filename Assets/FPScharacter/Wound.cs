using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wound : MonoBehaviour
{
    public float duration;
    public float multiplier;
    public bool bleedTemp = false;
    public bool bleedStopped = false;
    private Coroutine bleedRoutine;
    public WoundTypes woundType;
    public BodyParts bodyPart;
    public WoundsMarks woundsMark;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {      
        StartBleeding();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BleedEffect()
    {
        float timer = 0f;

        Debug.Log("Bleeding started!");

        while (timer < duration && !bleedStopped)
        {
            timer += Time.deltaTime;

            GameManager.instance.characterStats.TakeDamage(0.25f * multiplier * Time.deltaTime);
            
            if(timer < duration && bleedTemp)
            {
                bleedStopped = true;
            }
            yield return null; // Espera al siguiente frame
        }

        StopBleeding();
    }
    public void StartBleeding()
    {
        // Si ya hay una hemorragia corriendo, no iniciar otra
        if (bleedRoutine != null)
            StopCoroutine(bleedRoutine);

        bleedRoutine = StartCoroutine(BleedEffect());
    }

    public void StopBleeding()
    {
        if (bleedRoutine != null)
        {
            StopCoroutine(bleedRoutine);
            bleedRoutine = null;
        }

        Debug.Log("Bleeding stopped!");
    }

    void OnDestroy()
    {
        StopBleeding();
    }

    public void UseBandage()
    {
        woundsMark.bandage.gameObject.SetActive(true);
        StopBleeding();
    }
    public void SelectWound()
    {
        HealthManager.instance.selectedWound = this;
    }
}
