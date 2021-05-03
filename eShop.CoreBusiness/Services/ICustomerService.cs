using eShop.CoreBusiness.Models;

namespace eShop.CoreBusiness.Services
{
    public interface ICustomerService
    {
        string Uid { get; set; }

        Customer GetCustomerById( int id );
    }
}