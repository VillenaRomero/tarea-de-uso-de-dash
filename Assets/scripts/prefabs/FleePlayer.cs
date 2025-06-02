using UnityEngine;

public class FleePlayer : MonoBehaviour
{
    public Transform target;

    public float fleeDistance = 5f;
    void FixedUpdate()
    {
        if (target == null) return;

        if (Vector3.Distance(gameObject.transform.position, target.position) > fleeDistance)
        {
            Vector3 dir = transform.position - target.position;
            dir.y = 0;
            GetComponent<SteeringAgent>().ApplySteering(dir.normalized);
        }

    }
}
