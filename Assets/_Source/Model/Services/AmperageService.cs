using System;

namespace Model.Services
{
    public class AmperageService : ACircuitService
    {
        public override float Calculate(float power, float resistance)
        {
            float amperageSquared = power / resistance;
            float amperage = (float)Math.Sqrt(amperageSquared);

            return amperage;
        }
    }
}