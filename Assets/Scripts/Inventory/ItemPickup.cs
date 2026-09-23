using UnityEngine;

public class ItemPickup : MonoBehaviour, Iinteractor
{
    [SerializeField] private RenderingLayerMask outlineLayer;
    [SerializeField] private RenderingLayerMask originalLayer;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeReference][SerializeField] Item item;
    [SerializeField] int amoundToAdd;
    ItemInstance instance;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalLayer = meshRenderer.renderingLayerMask;
    }
    public void Interact()
    {
        if (GameManager.instance._playernventoryScript.AddItem(item, instance, amoundToAdd))
        {
            Destroy(gameObject);
        }
    }

    public void ReadyToInteract()
    {
        meshRenderer.renderingLayerMask = outlineLayer;
        GameManager.instance.playerHUD.interactIm[0].gameObject.SetActive(true);
        GameManager.instance.playerHUD.interactIm[1].gameObject.SetActive(true);
        GameManager.instance.playerHUD.interactInfo[0].text = item.name;
        GameManager.instance.playerHUD.interactInfo[1].text = "'E' To Pick Up";
    }

    public void StopInteraction()
    {
        meshRenderer.renderingLayerMask = originalLayer;
        GameManager.instance.playerHUD.interactIm[0].gameObject.SetActive(false);
        GameManager.instance.playerHUD.interactIm[1].gameObject.SetActive(false);

    }
}
