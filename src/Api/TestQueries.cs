namespace Api;

[ExtendObjectType(Name = "Query")]
public class TestQueries
{
    public Task<SickReport> GetProduct() =>
        Task.FromResult<SickReport>(new SickReport(
            "Jan", 
            "Jansen", 
            DateTime.Now.AddYears(-25), 
            DateTime.Now.AddDays(-30),
            "123456787",
            Gender.Male));
}