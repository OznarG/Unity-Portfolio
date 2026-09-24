using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("--- References/Components ---")]
    [SerializeField] GameObject inventoryHolder;
    GameObject[] slots;
    public Dictionary<string, int> itemsOnHand;
    public List<Slot> itemsInUse;
    public Item defaultEmptyItem;

    [Header("--- Drag Stats ---")]
    public int slotAmount;
    int slotNumber;
    public bool isOpen;

    private void Awake()
    {
        //Takes the amount of slots that the inventory has, then initiate the slots array
        slotAmount = inventoryHolder.transform.childCount;
        slots = new GameObject[slotAmount];
        //Populate the slot array and give parent an ID
        for(int i = 0; i < slotAmount; i++)
        {
            slots[i] = inventoryHolder.transform.GetChild(i).GetChild(0).gameObject;
            slots[i].GetComponentInParent<SlotBackground>().slotID = i;
        }
        //Initialite List and Dictionary
        itemsOnHand = new Dictionary<string, int>();
        itemsInUse = new List<Slot>();
    }

    public bool AddItem(Item itemStats, ItemInstance instance, int amount = 1)
    {
        //Created a slot to store the info
        //iterate through all the slots
        Slot tempSlot;
        for(int i = 0; i < slotAmount; i++)
        {
            //Set Slot information to current slot
            tempSlot = slots[i].GetComponent<Slot>();
            //if current slot is empty then Add the item to that lot and update it
            if (tempSlot.currentItem.stackAmount == 0)
            {
                tempSlot.AddItemToSlot(itemStats, amount);
                tempSlot.UpdateSlot();
                //updates items to the list of items 
                UpdateItemsOnHand(itemStats, amount);
                return true;
            }
            //if current item in slot is = to the slot item and the
            //slot still have space
            else if(tempSlot.currentItem.definition.ID == itemStats.ID && tempSlot.currentItem.stackAmount < itemStats.stackMax)
            {
                //Check how much items can fit in slot ans store it
                int fitAmount = (tempSlot.currentItem.definition.stackMax - tempSlot.currentItem.stackAmount);
                //If the amount is greater than the fit amount
                if(amount > fitAmount)
                {
                    //Put all the fit amount inside, of the current slot
                    tempSlot.currentItem.stackAmount += fitAmount;
                    tempSlot.UpdateSlot();
                    UpdateItemsOnHand(itemStats, fitAmount);
                    //now use recursive to into the Add Item again and this time with the amount left
                    //over from the previous AddItem 
                    AddItem(itemStats, instance, amount - fitAmount);
                }
                //since amount is not greater than fitamount
                else
                {
                    //Increase the stack by the amount, since it fits
                    fitAmount = amount;
                    tempSlot.currentItem.stackAmount += fitAmount;
                    tempSlot.UpdateSlot();
                    UpdateItemsOnHand(itemStats, fitAmount);
                }
                return true;
            }
        }
        //If this spot is reached that means it is full and the add item failed 
        return false;
    }
    public void RemoveItem(string item)
    {
        //Check every slot in the loop
        Slot invSlot;
        for (int i = 0; i < slotAmount; i++)
        {
            //Set slots to the current component
            //use get name and use it to see if it match the current item
            invSlot = slots[i].GetComponent<Slot>();
            string name = invSlot.currentItem.definition.itemName;
            //If the name match Decrease one and update slot
            if (name == item)
            {
                invSlot.currentItem.DecreaseAmount(1);
                itemsOnHand[item] -= 1;
                Debug.Log(itemsOnHand[item]);
                invSlot.UpdateSlot();
            }

        }
    }
    public void UpdateItemsOnHand(Item itemStats, int amount)
    {
        //Check if the item is already in the dictionary and add to it, else add a new one there
        if (itemsOnHand.ContainsKey(itemStats.itemName))
        {
            itemsOnHand[itemStats.itemName] += amount;
        }
        else
        {
            itemsOnHand.Add(itemStats.itemName, amount);
        }
    }
    public bool SlotEmpty(int index)
    {
        Slot slot = slots[index].gameObject.GetComponent<Slot>();
        return slot.currentItem.definition.ID == 0 ? true : false; 
    }
    public ItemInstance GetInstance(int index)
    {
        Slot slot = slots[index].gameObject.GetComponent<Slot>();
        return slot.currentItem;
    }
    public void EmptySlot(int index)
    {
        Slot slot = slots[index].gameObject.GetComponent<Slot>();
        slot.currentItem.stackAmount = 0;
        slot.UpdateSlot();
    }
}
