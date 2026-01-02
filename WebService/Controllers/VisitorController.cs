using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;
using WebService;
using WebService.DAL.Repository;

[ApiController]
[Route("[controller]/[action]")]
public class VisitorController : ControllerBase
{
    [HttpGet]
    public ActionResult<ProductCatalogViewModel> GetProduct(int usersRaitings=0, int minPrice=0, int maxPrice=0 )
    {
        ProductCatalogViewModel productCatalogViewModel = new ProductCatalogViewModel();
        DbContext dbContext = DbContext.GetInstance();
        UnitOfWork unitOfWork = new UnitOfWork(dbContext);

        try
        {


            dbContext.OpenConnection();
            productCatalogViewModel.Products = unitOfWork.ProductRepository.ReadByRaiting(usersRaitings, minPrice, maxPrice);
            productCatalogViewModel.Materials = unitOfWork.MaterialRepository.ReadAll();
            productCatalogViewModel.Brands = unitOfWork.BrandRepository.ReadAll();
            productCatalogViewModel.UsersRaitings = usersRaitings;
            productCatalogViewModel.MinPrice = minPrice;
            productCatalogViewModel.MaxPrice = maxPrice;
            return Ok(productCatalogViewModel);
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
        finally
        {
            dbContext.CloseConnection();
        }
    }
}
