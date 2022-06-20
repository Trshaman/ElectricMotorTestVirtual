namespace ElectricMotorTestVirtual.OOP_Approach.Motor
{
    public interface IMotorModel
    {
        int MotorId { get; set; }
        string MotorName { get; set; }
        int MotorSpeed { get; set; }
        TestCoefficents TestCoefficents { get; set; }
    }
}