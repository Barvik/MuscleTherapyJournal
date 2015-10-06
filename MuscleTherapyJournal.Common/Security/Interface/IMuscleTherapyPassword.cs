namespace MuscleTherapyJournal.Common.Security.Interface
{
    public interface IMuscleTherapyPassword
    {
        string GenerateSalt(int size);
        string GenerateHashedPassword(string psw, string salt);
    }
}
