using System;
using UnityEngine;

namespace Contracts
{
    [Serializable]
    public struct DialRotationData
    {
        public MeasurementType Type;
        public Vector3 Rotation;
    }
}