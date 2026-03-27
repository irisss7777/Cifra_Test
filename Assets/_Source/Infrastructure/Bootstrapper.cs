using System;
using Controller;
using Infrastructure.Database.Configs;
using Model;
using UnityEngine;
using View;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ElectricalCircuitConfig _circuitConfig;
        [SerializeField] private MultimeterView _multimeterView;
        [SerializeField] private MultimeterUiView _multimeterUiView;
        [SerializeField] private DialController _dialController;

        private MultimeterModel _model;

        private void Awake()
        {
            CreateMultimeter();
        }

        private void CreateMultimeter()
        {
            _model = new MultimeterModel(_dialController, _multimeterView, _circuitConfig, _multimeterUiView);
        }

        private void OnDestroy()
        {
            _model.Dispose();
        }
    }
}