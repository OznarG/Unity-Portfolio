using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Canvas canvas;
    [SerializeField] Sprite defaultImage;
    RectTransform rectTransform;
    Transform parentAfterDrag;
    SlotBackground slotBG;
    [SerializeField] Color itemColor;
    [SerializeField] Image imageItem;
    public ItemInstance currentItem;
    bool selected;
    bool isDragging;

    private void Awake()
    {
        //Get the components and initiate ItemInstance and set Raycast off
        rectTransform = GetComponent<RectTransform>();
        currentItem = new ItemInstance(GameManager.instance._playernventoryScript.defaultEmptyItem);
        GetComponentInChildren<TMP_Text>().raycastTarget = false;
        defaultImage = GetComponentInChildren<Image>().sprite;
        slotBG = GetComponentInParent<SlotBackground>();
        imageItem = GetComponentInChildren<Image>();

    }
    private void Start()
    {
        UpdateSlot();
    }
    public void AddItemToSlot(Item itemDef, int amount)
    {
        currentItem = new ItemInstance(itemDef, amount);
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        //check if the stack is empty
        if(currentItem.stackAmount <= 0)
        {
            //Set the Image to the empty spot and set children to 0
            GetComponent<Image>().sprite = defaultImage;
            GetComponentInChildren<TMP_Text>().text = " ";
            currentItem = new ItemInstance(GameManager.instance._playernventoryScript.defaultEmptyItem, 0);
            GetComponent<Image>().color = Color.black;
        }
        else
        {
            //if is not empty then just set image to the current icon
            //And then change the items number text to amount
            GetComponent<Image>().sprite = currentItem.definition.icon;
            if(currentItem.stackAmount >= 1)
            {
                GetComponentInChildren<TMP_Text>().text = currentItem.stackAmount.ToString();
                GetComponent<Image>().color = itemColor;
            }
        }
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
        // THIS IS CALLED ON THE ACTUAL BUTTON of the slot
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.GetComponent<Image>().raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        transform.SetParent(parentAfterDrag);
        transform.GetComponent<Image>().raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(currentItem.stackAmount <1)
        {
            return;
        }
        isDragging = true;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    #endregion

}
