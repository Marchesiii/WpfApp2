using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public interface IDbConnection
    {
        public void Close();
        public DbConnection GetConnection();
    }
}
