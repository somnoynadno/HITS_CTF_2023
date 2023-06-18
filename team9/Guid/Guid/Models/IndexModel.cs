namespace Guid.Models;

public class IndexModel
{
    public string Hash { get; set; }
    
    public string Expression { get; set; }
    
    public string Guid { get; set; }
    
    public bool IsWrong { get; set; }

    public IndexModel(string hash, string expression, string guid, bool isWrong)
    {
        Hash = hash;
        Expression = expression;
        this.Guid = guid;
        IsWrong = isWrong;
    }
}