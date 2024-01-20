using System.Data;

namespace FriendCaffe.Application.Configuration.Data;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();

}