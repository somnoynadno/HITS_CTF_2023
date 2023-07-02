namespace Task.Results;

public class ResultsService
{
    private string resultsTasks = "Hooray, there's still a little bit left. You're a real decryptor";
    
    private string flag = "HITS{asFDJAsdfsiajfmasDAEHDsdf}";

    public string GetResult()
    {
        return resultsTasks;
    }
    
    public string GetFlag()
    {
        return flag;
    }
}