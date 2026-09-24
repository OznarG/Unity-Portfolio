using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public struct ItemSpawnerConditions
{
    public int max;
    public int min;
    public Item item;
    public float chance;
    public int amount;
}
[System.Serializable]
public struct StoreItem
{
    public Item item;
    public int amount;
}
public class ItemSpawner : MonoBehaviour, Iinteractor
{
    [SerializeField] private RenderingLayerMask outlineLayer;
    [SerializeField] private RenderingLayerMask originalLayer;
    [SerializeField] private MeshRenderer meshRenderer;
    ItemInstance instance;

    [SerializeField] int amountSpawn;
    [SerializeField] string _name;
    [SerializeField] bool hasOpen;

    [SerializeField] List<StoreItem> items = new();
    [SerializeField] ItemSpawnerConditions[] ItemSpawnerConditions;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        for (int i = 0; i < ItemSpawnerConditions.Length; ++i)
        {
            PickRandomItems(i);
        }     
    }
    public void PickRandomItems(int currentItem)
    {
        int successNum = Random.Range(0, 100);
        Debug.Log(successNum + " Item Number " + currentItem);
        if(successNum <= ItemSpawnerConditions[currentItem].chance)
        {
            ItemSpawnerConditions[currentItem].amount =  Random.Range(ItemSpawnerConditions[currentItem].min, ItemSpawnerConditions[currentItem].max);
            StoreItem item;
            item.item = ItemSpawnerConditions[currentItem].item;
            item.amount = ItemSpawnerConditions[currentItem].amount;
            items.Add(item);
            Debug.Log(ItemSpawnerConditions[currentItem].amount);

        }
        else
        {
            ItemSpawnerConditions[currentItem].amount = 0;
        }
    }
    public void CloseInteract()
    {
        int lenght = GameManager.instance._countainerInventory.slotAmount;
        for (int i = 0;i < lenght; ++i)
        {
            if(!GameManager.instance._countainerInventory.SlotEmpty(i))
            {
                ItemInstance ins = GameManager.instance._countainerInventory.GetInstance(i);
                StoreItem item;
                item.item = ins.definition;
                item.amount = ins.stackAmount;
                items.Add(item);
                GameManager.instance._countainerInventory.EmptySlot(i);
            }
        }
    }
    public void ReadyToInteract()
    {
        //GameManager.instance.cameraScript.objectLookingAtStored.GetComponent<Iinteractor>().StopInteraction();
        meshRenderer.renderingLayerMask = outlineLayer;
        GameManager.instance.playerHUD.interactIm[0].gameObject.SetActive(true);
        GameManager.instance.playerHUD.interactIm[1].gameObject.SetActive(true);
        GameManager.instance.playerHUD.interactInfo[0].text = _name;
        GameManager.instance.playerHUD.interactInfo[1].text = "'E' To Open Chest";
    }

    public void Interact()
    {
        if (MenuManager.instance.isPaused)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            CloseInteract();
            MenuManager.instance.selectedMenu.SetActive(false);
            MenuManager.instance.selectedMenu = null;
            MenuManager.instance.isPaused = false;
        }
        else
        {
            foreach(StoreItem item in items)
            {
                GameManager.instance._countainerInventory.AddItem(item.item, instance, item.amount);
            }
            items.Clear();
            MenuManager.instance.selectedMenu = MenuManager.instance.inventoryMenu;
            MenuManager.instance.selectedMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            Cursor.visible = true;
            MenuManager.instance.isPaused = true;
        }
    }

    public void StopInteraction()
    {
        meshRenderer.renderingLayerMask = originalLayer;
        GameManager.instance.playerHUD.interactIm[0].gameObject.SetActive(false);
        GameManager.instance.playerHUD.interactIm[1].gameObject.SetActive(false);
    }
}
