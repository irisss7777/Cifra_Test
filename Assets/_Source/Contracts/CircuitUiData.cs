using System;
using TMPro;

namespace Contracts
{
    [Serializable]
    public struct CircuitUiData
    {
        public MeasurementType Type;
        public TMP_Text Text;
    }
}