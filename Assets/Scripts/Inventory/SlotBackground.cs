using UnityEngine;
using UnityEngine.EventSystems;

public enum SLOT_TYPE
{

}
public class SlotBackground : MonoBehaviour, IDropHandler
{
    [SerializeField] private Slot child;
    public SLOT_TYPE slotTypeTaker;
    public int slotID;
    public bool selected;
    [SerializeField] bool specialSlot;
    [SerializeField] Color slotColor;

    private void Awake()
    {
        selected = false;
        child = transform.GetComponentInChildren<Slot>();
    }
    public void UpdateSelection()
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        //Get the slot component of the image that the Cursor is grabbing, then calculate how much free space to stack it has
        Slot sourceSlot = eventData.pointerDrag.GetComponent<Slot>();

        throw new System.NotImplementedException();
    }
}
