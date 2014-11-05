using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public class VectorHelper
    {
        public static bool Less(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.x <= rhs.x)
                    && (lhs.y <= rhs.y)
                    && (lhs.z <= rhs.z);
        }

        public static bool Greater(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.x >= rhs.x)
                && (lhs.y >= rhs.y)
                && (lhs.z >= rhs.z);
        }
    }
}
