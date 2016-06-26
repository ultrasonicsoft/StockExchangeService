using System.Collections.Generic;
using System.Data;

namespace StockExchangeRepository.DbManager
{
    internal interface IDbManager
    {
        DataSet ExecuteProcedure(string procedureName, IList<KeyValuePair<string,object>> parameters=null);
    }
}