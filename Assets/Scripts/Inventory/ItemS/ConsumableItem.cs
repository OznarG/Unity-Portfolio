using UnityEngine;
[CreateAssetMenu(menuName = "Items/Consumable")]
public class ConsumableItem : Item
{
    public override void Use()
    {
        Debug.Log("Use Consumable");
        throw new System.NotImplementedException();
    }

}
