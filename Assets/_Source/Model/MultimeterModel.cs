using System;
using System.Collections.Generic;
using Contracts;
using Contracts.Configs;
using Contracts.Controllers;
using Contracts.View;
using Controller;
using Model.Services;
using View;

namespace Model
{
    public class MultimeterModel : IDisposable
    {
        private readonly IElectricalCircuitConfig _circuitConfig;
        private readonly IDialController _dialController;
        private readonly IMultimeterView _multimeterView;
        private readonly IMultimeterUiView _multimeterUiView;
        private readonly Dictionary<MeasurementType, ACircuitService> _circuitServices = new();

        private MeasurementType _currentType = MeasurementType.Off;

        public MultimeterModel(IDialController dialController, IMultimeterView multimeterView, IElectricalCircuitConfig circuitConfig, IMultimeterUiView multimeterUiView)
        {
            _dialController = dialController;
            _multimeterView = multimeterView;
            _circuitConfig = circuitConfig;
            _multimeterUiView = multimeterUiView;

            _dialController.MouseScrollDirection += OnMouseScroll;

            CreateServices();
        }

        private void CreateServices()
        {
            _circuitServices.Add(MeasurementType.Amperage, new AmperageService());
            _circuitServices.Add(MeasurementType.Voltage, new VoltageService());
            _circuitServices.Add(MeasurementType.AlternatingVoltage, new AlternatingVoltageService());
            _circuitServices.Add(MeasurementType.Resistance, new ResistanceService());
            _circuitServices.Add(MeasurementType.Neutral, new NeutralService());
        }

        private void OnMouseScroll(int direction)
        {
            ChangeType(direction);
    
            _multimeterView.SetDialRotation(_currentType);

            if (_circuitServices.TryGetValue(_currentType, out ACircuitService service))
            {
                var value = service.Calculate(_circuitConfig.Power, _circuitConfig.Resistance);
                _multimeterView.DisplayValue(value);
                _multimeterUiView.DisplayValue(value, _currentType);
            }
        }

        private void ChangeType(int direction)
        {
            int currentIndex = (int)_currentType;
            int newIndex = currentIndex + direction;

            MeasurementType[] values = (MeasurementType[])Enum.GetValues(typeof(MeasurementType));
            int length = values.Length;

            if (newIndex < 0)
                newIndex = length - 1;
            else if (newIndex >= length)
                newIndex = 0;

            _currentType = values[newIndex];
        }

        public void Dispose()
        {
            _dialController.MouseScrollDirection -= OnMouseScroll;
        }
    }
}