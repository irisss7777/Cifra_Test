using System;
using Contracts.Controllers;
using UnityEngine;
using View;

namespace Controller
{
    public class DialController : MonoBehaviour, IDialController
    {
        public event Action<int> MouseScrollDirection;
        
        [SerializeField] private MultimeterView _multimeterView;

        private bool _isHovered;

        private void Update()
        {
            if(_isHovered)
                MouseScroll();
        }

        private void MouseScroll()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if(scroll > 0)
                MouseScrollDirection?.Invoke(1);
            if(scroll < 0)
                MouseScrollDirection?.Invoke(-1);
        }

        private void OnMouseEnter()
        {
            _isHovered = true;
            _multimeterView.SetDialActive(true);
        }

        private void OnMouseExit()
        {
            _isHovered = false;
            _multimeterView.SetDialActive(false);
        }
    }
}