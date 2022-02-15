using Microsoft.AspNetCore.Mvc;
using TrendyTrees.Controllers;
using TrendyTrees.Models;
using Xunit;

namespace TrendyTrees.Tests
{
    public class ProductTests
    {
        [Fact]
        public void FirstProductMustBeKoreanFir()
        {
            var controller = new ProductsController();
            var result = controller.Details(1) as ViewResult;
            var product = (ProductViewModel)result.ViewData.Model;
            Assert.Equal("Korean fir", product.Name);
            Assert.True(product.Description.Length > 50);
        }
    }
}