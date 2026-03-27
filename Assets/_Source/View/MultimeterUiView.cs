using System.Collections.Generic;
using System.Linq;
using Contracts;
using Contracts.View;
using TMPro;
using UnityEngine;

namespace View
{
    public class MultimeterUiView : MonoBehaviour, IMultimeterUiView
    {
        [SerializeField] private CircuitUiData[] _uiData;

        private Dictionary<MeasurementType, TMP_Text> _textMap;

        private void Awake() =>
            _textMap = _uiData.ToDictionary(x => x.Type, x => x.Text);

        
        public void DisplayValue(float value, MeasurementType type)
        {
            foreach (var text in _textMap.Values)
                text.text = "0.00";

            if (_textMap.TryGetValue(type, out var targetText))
                targetText.text = value.ToString("F2");
        }
    }
}