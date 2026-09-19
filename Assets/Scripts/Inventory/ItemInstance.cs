using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public Item definition;
    public int stackAmount;

    public ItemInstance(Item definition, int ampunt = 0)
    {
        this.definition = definition;
        this.stackAmount = ampunt;
    }

    public void DecreaseAmount(int amount = 1)
    {
        stackAmount -= amount;
    }

    public void CopyCurrent(ItemInstance itemInstance)
    {
        if(itemInstance != null)
        {
            itemInstance.definition = definition;
        }
    }
}
