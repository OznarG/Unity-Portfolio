using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public struct ItemSpawnerConditions
{
    public int max;
    public int min;
    public Item item;
    public float chance;
    public float amount;
}
public class ItemSpawner : MonoBehaviour, Iinteractor
{
    [SerializeField] private RenderingLayerMask outlineLayer;
    [SerializeField] private RenderingLayerMask originalLayer;
    [SerializeField] private MeshRenderer meshRenderer;
    ItemInstance instance;

    [SerializeField] int minSpawn;
    [SerializeField] int maxSpawn;
    [SerializeField] int amountSpawn;
    [SerializeField] string _name;

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
            Debug.Log(ItemSpawnerConditions[currentItem].amount);

        }
        else
        {
            ItemSpawnerConditions[currentItem].amount = 0;
        }
    }

    public void ReadyToInteract()
    {
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
            MenuManager.instance.selectedMenu.SetActive(false);
            MenuManager.instance.selectedMenu = null;
            MenuManager.instance.isPaused = false;
        }
        else
        {
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
