namespace Model.Services
{
    public class NeutralService : ACircuitService
    {
        public override float Calculate(float power, float resistance)
        {
            return 0;
        }
    }
}