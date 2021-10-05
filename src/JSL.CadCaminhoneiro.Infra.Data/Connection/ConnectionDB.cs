using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace JSL.CadCaminhoneiro.Infra.Data.Connection
{
    public abstract class ConnectionDB
    {
        private readonly IConfiguration _configuration;

        protected ConnectionDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("CadCaminhoneiroDB"));
            }
        }
    }
}
