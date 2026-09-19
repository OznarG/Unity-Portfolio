using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public Item definition;
    public int stackAmpunt;

    public ItemInstance(Item definition, int ampunt = 1)
    {
        this.definition = definition;
        this.stackAmpunt = ampunt;
    }

    public void DecreaseAmount(int amount = 1)
    {
        stackAmpunt -= amount;
    }

    public void CopyCurrent(ItemInstance itemInstance)
    {
        if(itemInstance != null)
        {
            itemInstance.definition = definition;
        }
    }
}
