using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("--- Components/references ---")]
    public Item[] itemlist;
    public Camera mainCamera;
    public WeaponController weaponController;
    public FPSCharacterController fPSCharacterController;
    public FPSCharacterStats characterStats;
    public FPSPlayerCamera cameraScript;
    public GameObject _playerObj;
    public Inventory _playernventoryScript;
    public Inventory _countainerInventory;
    public PlayerHUD playerHUD;
    public GameObject selectedSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        cameraScript = mainCamera.GetComponent<FPSPlayerCamera>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
