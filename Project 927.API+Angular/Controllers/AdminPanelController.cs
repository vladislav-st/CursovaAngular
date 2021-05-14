using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_927.API_Angular.Helper;
using Project_927.DataAccess;
using Project_927.DTO.Market;
using Project_927.DTO.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_927.API_Angular.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : ControllerBase
    {
        EFContext _context;

        public AdminPanelController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IQueryable<ProductDTO> GetProducts()
        {
            var data = _context.Products.Select(t => new ProductDTO
            {
                
            });

            return data;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ResultDTO addProduct([FromBody] AddProductDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Code = 400,
                    Errors = CustomValidator.getErrorsByModelState(ModelState)
                };
            }

            _context.Products.Add(new DataAccess.Entity.Products
            {
                FullName = model.FullName,
                Description = model.Description,
                Img_URL = model.Img_URL,
                Price = model.Price
            });

            _context.SaveChanges();

            return new ResultDTO
            {
                Code = 200,
                Message = "Success!"
            };
        }

        [HttpGet("RemoveProduct/{Id}")]
        public ResultDTO RemoveProduct([FromRoute] int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(t => t.Id == id);

                _context.Products.Remove(product);
                _context.SaveChanges();

                return new ResultDTO
                {
                    Code = 200,
                    Message = "Success!"

                };
            }
            catch (Exception e)
            {
                List<string> temp = new List<string>();
                temp.Add(e.Message);

                return new ResultErrorDTO
                {
                    Code = 500,
                    Message = "ERROR",
                    Errors = temp
                };
            }
        }

        [HttpPost("editProduct/{id}")]
        public ResultDTO EditProduct([FromRoute] int id, [FromBody] ProductDTO model)
        {
            var product = _context.Products.FirstOrDefault(t => t.Id == id);

            product.FullName = model.FullName;
            product.Description = model.Description;
            product.Img_URL = model.Img_URL;
            product.Price = model.Price;

            _context.SaveChanges();

            return new ResultDTO
            {
                Code = 200,
                Message = "OK"
            };
        }


    }
}
