namespace Model.Services
{
    public class ResistanceService : ACircuitService
    {
        public override float Calculate(float power, float resistance)
        {
            return resistance;
        }
    }
}