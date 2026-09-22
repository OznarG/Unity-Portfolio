using UnityEngine;

public class ItemPickup : MonoBehaviour, Iinteractor
{
    [SerializeField] private RenderingLayerMask outlineLayer;
    [SerializeField] private RenderingLayerMask originalLayer;
    [SerializeField] private MeshRenderer meshRenderer;

    void Start()
    {
        originalLayer = meshRenderer.renderingLayerMask;
    }
    public void Interact()
    {
        meshRenderer.renderingLayerMask = outlineLayer;
    }

    public void ReadyToInteract()
    {
        meshRenderer.renderingLayerMask = outlineLayer;
    }

    public void StopInteraction()
    {
        meshRenderer.renderingLayerMask = originalLayer;

    }
}
