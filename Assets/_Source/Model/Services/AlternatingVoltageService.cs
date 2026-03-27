namespace Model.Services
{
    public class AlternatingVoltageService : ACircuitService
    {
        public override float Calculate(float power, float resistance)
        {
            return 0.01f;
        }
    }
}