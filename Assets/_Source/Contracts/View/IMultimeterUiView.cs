namespace Contracts.View
{
    public interface IMultimeterUiView
    {
        public void DisplayValue(float value, MeasurementType type);
    }
}