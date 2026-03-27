using System.Linq;
using Contracts;
using Contracts.View;
using TMPro;
using UnityEngine;

namespace View
{
    public class MultimeterView : MonoBehaviour, IMultimeterView
    {
        [Header("Value")]
        [SerializeField] private TMP_Text _displayValue;

        [Header("Dial")]
        [SerializeField] private GameObject _dialSelected;
        [SerializeField] private GameObject _dial;
        [SerializeField] private DialRotationData[] _dialRotationData;

        public void DisplayValue(float value) =>
            _displayValue.text = value.ToString("F2");

        public void SetDialActive(bool active) =>
            _dialSelected.SetActive(active);

        public void SetDialRotation(MeasurementType type)
        {
            bool canDisplay = type != MeasurementType.Off;
            
            _displayValue.gameObject.SetActive(canDisplay);
            
            var data = _dialRotationData.First(x => x.Type == type);

            _dial.transform.localRotation = Quaternion.Euler(data.Rotation.x, data.Rotation.y, data.Rotation.z);
        }
    }
}