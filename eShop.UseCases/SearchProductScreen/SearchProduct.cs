using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System.Collections.Generic;

namespace eShop.UseCases.SearchProductScreen
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository m_ProductRepository;
        public SearchProduct( IProductRepository productRepository )
        {
            this.m_ProductRepository = productRepository;
        }

        public IEnumerable<Product> Execute( string filter = null )
        {
           return m_ProductRepository.GetProducts( filter );
        }
    }
}
