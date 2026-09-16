using UnityEngine;

public class LineOfSight : MonoBehaviour
{ 
    [SerializeField] private LayerMask m_playerLayerMask;
    [SerializeField] private float m_detectionRange = 10.0f;
    [SerializeField] private float m_detectionHeight = 3f;
    [SerializeField] private bool showSebugVisuals = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PerformDetection(GameObject potentialTarget)
    {
        //create raycast to the target dirrection and only detect player mask
        RaycastHit hit;
        Vector3 direction = potentialTarget.transform.position - transform.position; 
        Physics.Raycast(transform.position + Vector3.up * m_detectionHeight, direction, out hit, m_detectionRange, m_playerLayerMask);
        //DrawLine to the target
        Debug.DrawLine(transform.position + Vector3.up * m_detectionHeight, potentialTarget.transform.position, Color.green);
        if (hit.collider == null)
        {   
            //TODO: find why player is returning null
            //if is null because it hits the player and return null for soem reason then it return the object
            return potentialTarget;
        }
        else
        {          
            return null;
        }
    }
}
