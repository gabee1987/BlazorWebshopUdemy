using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.SearchProductScreen
{
    public class SearchProduct
    {
        private readonly IProductRepository m_ProductRepository;
        public SearchProduct( IProductRepository productRepository )
        {
            this.m_ProductRepository = productRepository;
        }

        public IEnumerable<Product> Execute( string filter )
        {
           return m_ProductRepository.GetProducts( filter );
        }
    }
}
