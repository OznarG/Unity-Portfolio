using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SLOT_TYPE
{

}
public class SlotBackground : MonoBehaviour, IDropHandler
{
    [SerializeField] private Slot child;
    public SLOT_TYPE slotTypeTaker;
    [SerializeField] bool specialSlot;
    [SerializeField] Color slotSelectedColor;
    public int slotID;
    public bool selected;

    private void Awake()
    {
        selected = false;
        child = transform.GetComponentInChildren<Slot>();
    }
    private void SwitchItemsLocation(Slot sourceSlot, Slot sourceTwo)
    {
        ItemInstance tempitem = new ItemInstance(sourceTwo.currentItem.definition, sourceTwo.currentItem.stackAmount);
        
        sourceTwo.currentItem = sourceSlot.currentItem;
        sourceSlot.currentItem = tempitem;
        sourceTwo.UpdateSlot();
        sourceSlot.UpdateSlot();
    }
    public void UpdateSelection()
    {
        if (GameManager.instance.selectedSlot.GetComponentInParent<SlotBackground>().selected)
        {
            
            transform.GetComponent<Image>().color = slotSelectedColor;
        }
        else
        {
            transform.GetComponent<Image>().color = Color.black;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Get the slot component of the image that the Cursor is grabbing, then calculate how much free space to stack it has
        Slot sourceSlot = eventData.pointerDrag.GetComponent<Slot>();
        if (sourceSlot.currentItem.stackAmount < 1)
        {
            return;
        }
        int freeSpace = child.currentItem.definition.stackMax - child.currentItem.stackAmount;
        //If the item you grabing is equals to the item below it
        if (child.currentItem.definition.ID == sourceSlot.currentItem.definition.ID)
        {
            //If it can hold all items that were grabbed
            if (freeSpace >= sourceSlot.currentItem.stackAmount)
            {
                //Add all stock amount, delete item from source slot, Update the Slot(run checks etc), Update the source slote too
                int amount = sourceSlot.currentItem.stackAmount;
                sourceSlot.currentItem.DecreaseAmount(sourceSlot.currentItem.stackAmount);
                child.currentItem.stackAmount += amount;

                sourceSlot.UpdateSlot();
                child.UpdateSlot();

            }
            //If not all items fit
            else
            {
                //Fill it to max, subtract what you place on the child slot from the source slot, update both slots
                child.currentItem.stackAmount += freeSpace;
                sourceSlot.currentItem.DecreaseAmount(freeSpace);
                child.UpdateSlot();
                sourceSlot.UpdateSlot();
            }
        }
        //If the items are not the same
        if (child.currentItem.stackAmount <= 0)
        {
            child.currentItem = new ItemInstance(sourceSlot.currentItem.definition, sourceSlot.currentItem.stackAmount);
            child.currentItem.CopyCurrent(sourceSlot.currentItem);
            sourceSlot.currentItem = new ItemInstance(GameManager.instance._playernventoryScript.defaultEmptyItem, 0);
            child.UpdateSlot();
            sourceSlot.UpdateSlot();
            //return;
        }
        else
        {
            //Swap items location
            SwitchItemsLocation(sourceSlot, child);
            return;
        }

    }
    
}
