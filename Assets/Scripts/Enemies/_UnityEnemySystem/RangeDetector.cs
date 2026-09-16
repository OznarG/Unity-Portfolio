using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private LayerMask detectionMask;
    [SerializeField] private bool showDeubVisuals = true;

    public GameObject DetectedTarget
    {  get; set; }

    public GameObject UpdateDetector()
    {
        //get all the colliders with player Tack on them
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionMask);
        //if there is more than one grab the first one 
        if(colliders.Length > 0)
        {
            DetectedTarget = colliders[0].gameObject;
        }
        //if there are none then return null
        else
        {
            DetectedTarget = null;
        }
        return DetectedTarget;
    }
    //This draw the circle
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
