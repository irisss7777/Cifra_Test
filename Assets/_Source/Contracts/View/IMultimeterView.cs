namespace Contracts.View
{
    public interface IMultimeterView
    {
        public void DisplayValue(float value);
        public void SetDialRotation(MeasurementType type);
    }
}