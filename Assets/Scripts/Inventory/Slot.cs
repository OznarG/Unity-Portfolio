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
