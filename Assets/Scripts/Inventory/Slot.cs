using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] bool selected;
    [SerializeField] Canvas canvas;
    [SerializeField] Sprite defaultImage;
    bool isDragging;
    RectTransform rectTransform;
    Transform parentAfterDrag;
    SlotBackground slotBG;
    public ItemInstance currentItem;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //currentItem = new ItemInstance(GameManager.instance)
        GetComponentInChildren<Text>().raycastTarget = false;
        defaultImage = GetComponentInChildren<Image>().sprite;
        slotBG = GetComponentInParent<SlotBackground>();
    }
    public void AddItemToSlot(Item itemDef, int amount)
    {
        currentItem = new ItemInstance(itemDef, amount);
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        if(currentItem.stackAmount <= 0)
        {
            GetComponent<Image>().sprite = defaultImage;
            GetComponentInChildren<Text>().text = " ";
            //currentItem = new ItemInstance(GameManager.instance.playerInventory.defaultEmptyItem, 0);
        }
        else
        {
            GetComponent<Image>().sprite = currentItem.definition.icon;
            if(currentItem.stackAmount >= 1)
            {
                GetComponentInChildren<Text>().text = currentItem.stackAmount.ToString();
            }
        }
        UpdateParentBackground(); //Don't need it in this game
    }
    private void UpdateParentBackground() 
    {

    }
    public void SelectThis()
    {
        //If is not dragging it means it was clicked
        if (!isDragging)
        {
            //if this is set as selected
            if (transform.GetComponentInParent<SlotBackground>().selected)
            {
                //unselect it because it wwas clicked again
                transform.GetComponentInParent<SlotBackground>().selected = false;
                GameManager.instance.selectedSlot.GetComponentInParent<SlotBackground>().UpdateSelection();
            }
            else
            {
                //if is not selected set selected to false and update to change its color and avoid errors
                GameManager.instance.selectedSlot.GetComponentInParent<SlotBackground>().selected = false;
                GameManager.instance.selectedSlot.GetComponentInParent<SlotBackground>().UpdateSelection();
                //now set the selectedSlot to this one
                GameManager.instance.selectedSlot = transform.gameObject;
                //update it to selected and change color 
                GameManager.instance.selectedSlot.GetComponentInParent<SlotBackground>().selected = true;
                GameManager.instance.selectedSlot.GetComponentInParent<SlotBackground>().UpdateSelection();
            }
        }
    }
    public bool IsEmpty()
    {
        if (currentItem.stackAmount == 0)
        {
            return true;
        }
        return false;
    }
    #region Drag Methods
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    #endregion

}
