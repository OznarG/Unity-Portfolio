using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] private LayerMask m_playerLayerMask;
    [SerializeField] private float m_detectionRange = 10.0f;
    [SerializeField] private float m_detectionHeight = 3f;
    [SerializeField] private bool showSebugVisuals = true;
    [SerializeField] GameObject oj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PerformDetection(GameObject potentialTarget)
    {
        RaycastHit hit;
        Vector3 direction = potentialTarget.transform.position - transform.position; 
        Physics.Raycast(transform.position + Vector3.up * m_detectionHeight, direction, out hit, m_detectionRange, m_playerLayerMask);
        Debug.Log("Shotting Ray?");
        Debug.Log(potentialTarget);
        Debug.Log(hit.collider);
        Debug.DrawLine(transform.position + Vector3.up * m_detectionHeight, potentialTarget.transform.position, Color.green);
        if (hit.collider == null)
        {

            
            return potentialTarget;

        }
        else
        {
            
            return null;
        }
    }
}
