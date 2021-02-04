using AutoMapper;
using DataAccessLayer.BaseContract;
using DataAccessLayer.DbContext;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ProductServices
{
    public interface IProductService : IBaseAsyncRepository<RemoveProductDto
        ,GetAllProductDto,UpdateProductDto,InsertProductDto,int>
    {
        Task<GetAllProductDto> GetByAsync(int id);
        Task<GetAllProductDto> GetByAsync(string name);
        Task<List<ProductIndexPageDetailDto>> GetProductForIndexPage();
    }
    public class ProductService : IProductService
    {
        private readonly GameShopDbContext gameShopDbContext;
        private readonly IMapper mapper;
        private readonly DbSet<Product> products;
        public ProductService(GameShopDbContext gameShopDbContext,IMapper mapper)
        {
            this.gameShopDbContext = gameShopDbContext;
            this.mapper = mapper;
            products = gameShopDbContext.Set<Product>();
        }

        public async Task<IEnumerable<GetAllProductDto>> GetAllAsync()
        {
            var productList = await products.AsNoTracking().ToListAsync();
            var productDtoList = mapper.Map<List<GetAllProductDto>>(productList);
            return productDtoList;
        }

        public async Task<GetAllProductDto> GetByAsync(int id)
        {
            var product = await products.FirstOrDefaultAsync(c => c.Id == id);
            var productDto = mapper.Map<GetAllProductDto>(product);
            return productDto;
        }

        public async Task<GetAllProductDto> GetByAsync(string name)
        {
            var product = await products.FirstOrDefaultAsync(c => c.Name.ToLower() == name);
            var productDto = mapper.Map<GetAllProductDto>(product);
            return productDto;
        }

        public async Task<List<ProductIndexPageDetailDto>> GetProductForIndexPage()
        {
            var productsList =await products.Select(c=> new Product{
            Id=c.Id,
            Name=c.Name,
            Price=c.Price,
            Picture=c.Picture,
            Slug=c.Slug
            }).ToListAsync();
            var productDtos = mapper.Map<List<ProductIndexPageDetailDto>>(productsList);
            return productDtos;
        }

        public async Task<int> InsertAsync(InsertProductDto entity, CancellationToken token, bool isSave = false)
        {
            Product mapperObject = mapper.Map<Product>(entity);
            products.Add(mapperObject);
            if (isSave)
               return await SaveChangesAsync(token);
            return 1;
        }

        public void Remove(RemoveProductDto entity, bool isSave = false)
        {
            var mapperObject = mapper.Map<Product>(entity);
            products.Remove(mapperObject);
            if (isSave)
                SaveChanges();
        }

        public void Remove(int key, bool isSave = false)
        {
            var productObject = new Product()
            {
                Id = key
            };
            products.Remove(productObject);
            if (isSave)
                SaveChanges();
        }

        public int SaveChanges()
        {
            return gameShopDbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken token)
        {
            return gameShopDbContext.SaveChangesAsync(token);
        }

        public UpdateProductDto Update(UpdateProductDto entity, bool isSave = false)
        {
            var mapperOnject = mapper.Map<Product>(entity);
            products.Update(mapperOnject);
            if (isSave)
                SaveChanges();
            return entity;
        }

    }
}
