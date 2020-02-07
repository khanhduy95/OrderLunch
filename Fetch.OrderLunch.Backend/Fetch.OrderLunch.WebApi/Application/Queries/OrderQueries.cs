using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private string _connectionString = string.Empty;

        public OrderQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<Order> GetOrder(int id)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<dynamic>(
                    @""
                    );
            }
            return null;
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
