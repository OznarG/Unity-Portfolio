using UnityEngine;

[System.Serializable]
public struct ItemSpawnerConditions
{
    public int max;
    public int min;
    public Item item;
    public float chance;
    public float amount;
}
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] int minSpawn;
    [SerializeField] int maxSpawn;
    [SerializeField] int amountSpawn;

    [SerializeField] ItemSpawnerConditions[] ItemSpawnerConditions;

    private void Start()
    {
        for (int i = 0; i < ItemSpawnerConditions.Length; ++i)
        {
            PickRandomItems(i);
        }
        
    }
    public void PickRandomItems(int currentItem)
    {
        int successNum = Random.Range(0, 100);
        if(successNum <= ItemSpawnerConditions[currentItem].chance)
        {
            ItemSpawnerConditions[currentItem].amount =  Random.Range(minSpawn, maxSpawn);
        }
        else
        {
            ItemSpawnerConditions[currentItem].amount = 0;
        }
    }
}
