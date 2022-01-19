using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            
            for(int i = 0; i < transform.childCount; i++)
            {
                Gizmos.color = new Color(32, 32, 32, 0.7f);
                Gizmos.DrawSphere(GetWaypoint(i), 0.4f);
                Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(GetNextIndex(i)));
            }
        }

        public int GetNextIndex(int i)
        {
            if (i == transform.childCount - 1) return 0;
            return i + 1;
        }

        public Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}
