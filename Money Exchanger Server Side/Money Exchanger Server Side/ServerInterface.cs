using System.Data;
namespace Money_Exchanger_Server_Side
{
    public interface ServerInterface
    {
        bool SalesMan_Login(string uname, string password);
        DataSet GetLatestRatesFromServer(); // Return buy sell rate of foreign currencies to pakistani currency
        int Transaction(string operat,string cname, string cnic, string cell,                                                         
        bool by, string cur_symbol, float rate, float amount);
        bool ChanegeUserPasswod(string un, string oldpass, string newpass);
    }
}



















