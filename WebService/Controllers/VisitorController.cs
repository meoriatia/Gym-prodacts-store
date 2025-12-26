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
    public ActionResult<List<Product>> GetProduct()
    {
        DbContext dbContext = DbContext.GetInstance();
        UnitOfWork unitOfWork = new UnitOfWork(dbContext);

        try
        {
            dbContext.OpenConnection();
            var Product = unitOfWork.ProductRepository.ReadAll();
            return Ok(Product); // מחזיר HTTP 200 עם הרשימה
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
