using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace UnityBlocks.Idle
{
    public class SimplePath : MonoBehaviour
    {
        [SerializeField] private List<Transform> points;

        public List<Transform> Points => points;

        public Vector3[] PointsVector()
        {
            var pointsVector = new Vector3[points.Count];
            for (var index = 0; index < points.Count; index++)
            {
                var point = points[index];
                pointsVector[index] = point.position;
            }

            return pointsVector;
        }

        [Button]
        private void FillPoints()
        {
            points.Clear();
            for (var i = 0; i < transform.childCount; i++)
            {
                points.Add(transform.GetChild(i));
            }
        }
    }
}