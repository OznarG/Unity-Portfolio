using UnityEngine;

[CreateAssetMenu(menuName = "Items/Health")]
public class HealthItem : Item
{
    float healthAmount;

    public override void Use()
    {
        Debug.Log("Use Health");
        throw new System.NotImplementedException();
    }
}
