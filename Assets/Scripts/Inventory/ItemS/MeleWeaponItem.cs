using UnityEngine;

[CreateAssetMenu(menuName = "Items/Melee")]
public class MeleWeaponItem : Item
{
    public override void Use()
    {
        Debug.Log("using Melee");
        throw new System.NotImplementedException();
    }

}
