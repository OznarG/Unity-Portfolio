using UnityEngine;

[CreateAssetMenu(menuName = "Items/Material")]
public class MaterialItem : Item
{
    public override void Use()
    {
        Debug.Log("Use Material");
        throw new System.NotImplementedException();
    }
}
