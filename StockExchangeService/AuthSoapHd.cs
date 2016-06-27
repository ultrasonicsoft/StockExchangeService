using System.Web.Services.Protocols;

namespace StockExchange
{
    public class AuthSoapHd : SoapHeader
    {
        public string strUserName;
        public string strPassword;
    }
}