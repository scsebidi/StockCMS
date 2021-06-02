using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiphoCoreApi.Implimentation;
using SiphoCoreApi.Model;

namespace SiphoCoreApi.Controllers
{
    public class StockController : Controller
    {
        private StockData _stockdata;

        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetStock()
        {
            try
            {
                var stock = _stockdata.GetStockItems();
                return Ok(stock);
            }
            catch (Exception)
            {
                throw;
            }
         
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddStock(StockItemModel stockItem)
        {
            try
            {
               var stock = _stockdata.AddStock(stockItem);
                return Ok(stock);
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateStockItem(Guid id,StockItemModel stockItem)
        {
            try
            {
                var stockExists = _stockdata.GetBy(id);
                if (stockExists != null)
                {
                    stockItem.id = stockExists.id;
                    _stockdata.UpdateStock(stockItem);
                } 
                return Ok(stockItem);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteStock(Guid id)
        {
            try
            {
                var stock = _stockdata.GetBy(id);
                if (stock != null)
                {
                    _stockdata.DeleteStock(stock);
                    return Ok($"Deleted {stock}");
                }
                return NotFound($"Stock item {id} not found");
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
