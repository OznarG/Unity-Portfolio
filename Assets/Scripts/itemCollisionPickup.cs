using UnityEngine;

public class itemCollisionPickup : MonoBehaviour
{
    [SerializeField] bool playerIn;
    [SerializeReference][SerializeField] Item item;
    [SerializeField] int amoundToAdd;
    ItemInstance instance;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && playerIn == false)
        {
            playerIn = true;
            if (GameManager.instance._playernventoryScript.AddItem(item, instance, 1)) ;
            {
                Destroy(gameObject); 
            }
        }
    }
}
