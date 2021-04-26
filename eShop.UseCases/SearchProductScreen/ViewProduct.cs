using eShop.CoreBusiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.UseCases.SearchProductScreen
{
    public class ViewProduct
    {
        private readonly IProductRepository m_ProductRepository;
        public ViewProduct( IProductRepository productRepository )
        {
            this.m_ProductRepository = productRepository;
        }

        public Product Execute( int id )
        {
            return m_ProductRepository.GetProduct( id );
        }
    }
}
