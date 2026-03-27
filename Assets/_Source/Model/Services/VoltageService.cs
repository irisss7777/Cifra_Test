using System;

namespace Model.Services
{
    public class VoltageService : ACircuitService
    {
        public override float Calculate(float power, float resistance)
        {
            float amperageSquared = power / resistance;
            float amperage = (float)Math.Sqrt(amperageSquared);

            float voltage = power / amperage;

            return voltage;
        }
    }
}