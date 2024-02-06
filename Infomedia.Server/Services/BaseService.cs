using Microsoft.Data.SqlClient;

namespace Infomedia.Server.Services;

public abstract class BaseService
{
    protected readonly IConfiguration _configuration;

    protected BaseService(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    // This is base service where we need to define the data we will be using in all other services
    // As database connections or api keys
    protected SqlConnection Connection
    {
        get
        {
            return new SqlConnection(_configuration.GetConnectionString("Infomedia"));
        }
    }

    protected string ApiKey
    {
        get
        {
            return "7df3371c24164a1f9a9f4da443dad4b9";
        }
    }
}
