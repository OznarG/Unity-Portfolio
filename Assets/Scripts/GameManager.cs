using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("--- Components/references ---")]
    public Camera mainCamera;
    public WeaponController weaponController;
    public FPSCharacterController fPSCharacterController;
    public GameObject _playerObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
