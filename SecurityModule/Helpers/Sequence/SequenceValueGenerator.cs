using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Helpers.Sequence
{
    public class SequenceValueGenerator
    {
        private string _sequenceName;

        public SequenceValueGenerator(string sequenceName)
        {
            this._sequenceName = sequenceName;
        }
        public int Next()
        {
            var context = new SecurityDBContext();
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                //command.CommandText = $"SELECT {_sequenceName}.NEXTVAL FROM DUAL";
                command.CommandText = $"SELECT NEXT VALUE FOR [dbo].[{_sequenceName}]";
                //SELECT NEXT VALUE FOR [dbo].[Product_seq]
                context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    int id = reader.GetInt32(0);
                    return id;
                }
            }
        }
    }
}
