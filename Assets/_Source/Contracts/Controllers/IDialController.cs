using System;

namespace Contracts.Controllers
{
    public interface IDialController
    {
        public event Action<int> MouseScrollDirection;
    }
}