
public class Options
{
    public string[] Regions = {"eu-west-1", "me-central-1"};
    public string[] Environments = {"dev", "qa", "uat", "prod"};
    public string[] Projects = {"GMM", "FAB", "WARBA"}; 
    public string[] Accounts = {"rwrd057", "rwrd058", "rwrd073"};
    public List<SubOption> AccountSubOptions { get; set; } = new();

    public void CreateAccountSubOptions()
    {
        AccountSubOptions.Add(new SubOption() {Name = "rwrd057", Values = new List<string>(new[]{"dev", "sbx1", "sbx5"})});
        AccountSubOptions.Add(new SubOption() {Name = "rwrd058", Values = new List<string>(new[]{"qa", "uat", "uat3"})});
        AccountSubOptions.Add(new SubOption() {Name = "rwrd073", Values = new List<string>(new[]{"prod"})});
    }
}

public record SubOption
{
    public string Name { get; set; }
    public List<String> Values { get; set; }
}