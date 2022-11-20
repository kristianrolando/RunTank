using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Waypoint> connectedPoint;

    void OnDrawGizmosSelected()
    {
        if (connectedPoint != null)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < connectedPoint.Count; i++)
            {
                Gizmos.DrawLine(gameObject.transform.position, connectedPoint[i].transform.position);
            }
        }
    }
}
