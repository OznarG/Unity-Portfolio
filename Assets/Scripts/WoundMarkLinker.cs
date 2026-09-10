using UnityEngine;
using UnityEngine.UI;

public class WoundMarkLinker : MonoBehaviour
{
    public Button selector;
    public Wound wound;
    public Image selectionhighlight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selector.onClick.AddListener(SelectWound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SelectWound()
    {
        if(HealthManager.instance.selectionhighlight != null)
        {
            HealthManager.instance.selectionhighlight.gameObject.SetActive(false);
        }

        wound.SelectWound();    
        HealthManager.instance.selectionhighlight = selectionhighlight;
        selectionhighlight.gameObject.SetActive(true);
    }

}
