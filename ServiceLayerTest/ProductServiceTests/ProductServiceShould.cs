using AutoMapper;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceLayer.Dtos.ProductDtos;
using ServiceLayer.Services.ProductServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ServiceLayerTest.ProductServiceTests
{
    [Trait("Category","Product")]
    public class ProductServiceShould:DbContextTestInstance
    {
        [Fact]
        public void RemoveProductById()
        {
            AddSampleProduct();

            //arrange
            var mapperMoq = new Mock<IMapper>().Object;
            ProductService productService = new ProductService(DbContext,mapperMoq);
            
            //act
            productService.Remove(1, true);

            //assert
            Assert.Empty(DbContext.Set<Product>());
        }
        [Fact]
        public void CanNotRemoveProductByInvalidId()
        {
            var mapperMoq = new Mock<IMapper>().Object;
            ProductService productService = new ProductService(DbContext, mapperMoq);
            Assert.Throws<DbUpdateConcurrencyException>( ()=> productService.Remove(12,true));
            
        }
        [Fact]
        public void RemoveProductWithOutAnyId()
        {
            var mapperMoq = new Mock<IMapper>().Object;
            ProductService productService = new ProductService(DbContext, mapperMoq);
            Assert.Throws<ArgumentNullException>(() => productService.Remove(new RemoveProductDto(), true));
        }
        [Fact]
        public void RemoveProductWithObject()
        {
            AddSampleProduct();

            //arrange
            var mapperInstance=InfrastructureFunctions.GetMapperInstance();
            
            ProductService productService = new ProductService(DbContext, mapperInstance);
            
            //act
            productService.Remove(new RemoveProductDto() { 
            Id=1}, true);

            //assert
            Assert.Empty(DbContext.Set<Product>());
        }
        [Fact]
        public async void ListOfProductsWillBeNotNull()
        {
            var mapper=InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            Assert.NotNull(await productService.GetAllAsync());
        }
        [Fact]
        public async void InsertProductWithNullProperties()
        {
            var mapper = InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            await Assert.ThrowsAsync<DbUpdateException>(() => productService.InsertAsync(new InsertProductDto(),CancellationToken.None,true));
        }
        [Fact]
        public async void GetProductById()
        {
            AddSampleProducts();
            var mapper = InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            var result=await productService.GetByAsync(1);
            Assert.Equal(DbContext.Set<Product>().FirstAsync(c=>c.Id==1).Result, result);
        }
        [Fact]
        public async void GetProductByWrongId()
        {
            var mapper = InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            var result = await productService.GetByAsync(1);
            Assert.Null(result);
        }
        [Fact]
        public async void GetProductWithName()
        {
            AddSampleProducts();
            var mapper = InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            var result=await productService.GetByAsync("xxxxx");
            Assert.Equal(DbContext.Set<Product>().FirstOrDefaultAsync(c => c.Name == "xxxxx").Result, result);
        }
        [Fact]
        public async void GetProductWithWrongName()
        {
            var mapper = InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            var result = await productService.GetByAsync("x");
            Assert.Null(result);
        }
        [Fact]
        public void UpdateProductWithWrongId()
        {
            var mapper = InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            var product = AddSampleProduct();
            product.Id = -1;
            var productDto=mapper.Map<Product, UpdateProductDto>(product);
            Assert.Throws<DbUpdateConcurrencyException>( () => productService.Update(productDto,true));
        }
        [Fact]
        public void UpdateProduct()
        {
            var mapper = InfrastructureFunctions.GetMapperInstance();
            ProductService productService = new ProductService(DbContext, mapper);
            var product = AddSampleProduct();
            product.Name = "test1";
            product.Detail = "test2";
            var productDto = mapper.Map<Product, UpdateProductDto>(product);
            var productDtoResult = productService.Update(productDto, true);
            Assert.Equal(productDto, productDtoResult);
        }
        private Product AddSampleProduct()
        {
            var sampleProduct = new Product()
            {
                Detail = "xxxx",
                Discount = 10,
                Name = "xxxxx",
                Picture = "xxxx",
                Price = 3000,
            };
            DbContext.Add(sampleProduct);
            DbContext.SaveChanges();
            DbContext.Entry(sampleProduct).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return sampleProduct;
        }
        private void AddSampleProducts()
        {
            for(int i = 0; i < 10; i++)
            {
                var sampleProduct = new Product()
                {
                    Detail = "xxxx",
                    Discount = 10,
                    Name = "xxxxx",
                    Picture = "xxxx",
                    Price = 3000,
                };
                DbContext.Add(sampleProduct);
                DbContext.SaveChanges();
                DbContext.Entry(sampleProduct).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            }
        }
    }
}
