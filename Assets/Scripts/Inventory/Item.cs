using UnityEngine;
public enum ITEMTYPE
{

}
public abstract class Item : ScriptableObject
{
    public int ID;
    public ITEMTYPE type;
    public string itemName;
    public string itemDescription;
    public int stackMax;
    public bool usable;
    public Sprite icon;
    public GameObject iemPrefabs;
    public SLOT_TYPE slotType;
    public int slotIndex;

    public abstract void Use();
}
