using UnityEngine;
using UnityEngine.UI;

public class WoundMarkLinker : MonoBehaviour
{
    public Button selector;
    public Wound wound;
    public Image selectionhighlight;
    
    void Start()
    {
        //bind the button so when is clicked it calls select wound
        selector.onClick.AddListener(SelectWound);
    }

    public void SelectWound()
    {
        //When is called it checks if it has a highligh image  to false becasue is a different oen selected
        //in the selectionhighlight
        if(HealthManager.instance.selectionhighlight != null)
        {
            HealthManager.instance.selectionhighlight.gameObject.SetActive(false);
        }
        //calls select wound on this wound, wish just added it to the Health Manager
        //Then turn on the selection image
        wound.SelectWound(selectionhighlight.gameObject);    
        HealthManager.instance.selectionhighlight = selectionhighlight;
        
    }

}
