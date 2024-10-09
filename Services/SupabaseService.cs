using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Supabase;

namespace api.Services
{
    public class SupabaseService
    {
          private readonly Client _supabaseClient;

        public SupabaseService(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        // Get all products
        public async Task<List<Product>> GetAllProducts()
        {
            var response = await _supabaseClient.From<Product>().Get();
            return response.Models;
        }

        // // Get product by ID
        public async Task<Product?> GetProductById(int id)
        {
            var response = await _supabaseClient.From<Product>().Where(x=>x.id==id).Single();
            return response;
        }

        // // Add a new product
        public async Task<Product?> AddProduct(Product product)
        {
            var response = await _supabaseClient.From<Product>().Insert(product);
            // return response.Models.FirstOrDefault();
            return response.Model;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try{
            await _supabaseClient.From<Product>().Where(x => x.id == id).Delete();
            return true;
            }
            catch(Exception){
                return false;
                throw;
            }
        }
    }
}