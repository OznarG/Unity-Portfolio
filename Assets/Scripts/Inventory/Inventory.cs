using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryHolder;
    GameObject[] slots;
    public Dictionary<string, int> itemsOnHand;
    public List<Slot> itemsInUse;
    public Item defaultEmptyItem;

    [Header("--- Drag Stats ---")]
    int slotAmount;
    int slotNumber;
    public bool isOpen;

    private void Awake()
    {
        slotAmount = inventoryHolder.transform.childCount;
        slots = new GameObject[slotAmount];
        for(int i = 0; i < slotAmount; i++)
        {
            slots[i] = inventoryHolder.transform.GetChild(i).GetChild(0).gameObject;
            slots[i].GetComponentInParent<SlotBackground>().slotID = i;
        }
        itemsOnHand = new Dictionary<string, int>();
        itemsInUse = new List<Slot>();
    }

    public bool AddItem(Item itemStats, ItemInstance instance, int amount = 1)
    {
        Slot tempSlot;
        for(int i = 0; i < slotAmount; i++)
        {
            tempSlot = slots[i].GetComponent<Slot>();
            if (tempSlot.currentItem.stackAmount == 0)
            {
                tempSlot.AddItemToSlot(itemStats, amount);
                tempSlot.UpdateSlot();

                if(itemsOnHand.ContainsKey(itemStats.itemName)) 
                {
                    itemsOnHand[itemStats.itemName] += amount;
                }
                else
                {
                    itemsOnHand.Add(itemStats.itemName, amount);
                }
                return true;
            }
            else if(tempSlot.currentItem.definition.ID == itemStats.ID && tempSlot.currentItem.stackAmount < itemStats.stackMax)
            {
                int fitAmount = (tempSlot.currentItem.definition.stackMax - tempSlot.currentItem.stackAmount);
                if(amount > fitAmount)
                {
                    tempSlot.currentItem.stackAmount += fitAmount;
                    tempSlot.UpdateSlot();
                    if(itemsOnHand.ContainsKey(itemStats.itemName))
                    {
                        itemsOnHand[itemStats.itemName] += fitAmount;
                    }
                    else
                    {
                        itemsOnHand.Add(itemStats.itemName, fitAmount);
                    }
                    AddItem(itemStats, instance, amount - fitAmount);
                }
                else
                {
                    fitAmount = amount;
                    tempSlot.currentItem.stackAmount += fitAmount;
                    tempSlot.UpdateSlot();
                    if (itemsOnHand.ContainsKey(itemStats.itemName))
                    {
                        itemsOnHand[itemStats.itemName] += fitAmount;
                    }
                    else
                    {
                        itemsOnHand.Add(itemStats.itemName, fitAmount);
                    }
                }
                return true;
            }
        }
        return false;
    }
    public void RemoveItem(string item)
    {
        Slot invSlot;
        for (int i = 0; i < slotAmount; i++)
        {
            invSlot = slots[i].GetComponent<Slot>();
            string name = invSlot.currentItem.definition.itemName;
            if (name == item)
            {
                invSlot.currentItem.DecreaseAmount(1);
                invSlot.UpdateSlot();
            }
        }
    }
}
