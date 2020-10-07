using System.Threading.Tasks;

namespace eShop.Models.Interfaces
{
    public interface IAuth
    {
        Task Register(int userId, string email, string firstname, string lastname, string username, string password, string role);
        Task Login(string email, string password);
    }
}
