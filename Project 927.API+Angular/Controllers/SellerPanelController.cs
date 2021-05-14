using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_927.API_Angular.Controllers
{
    [Route("api/Seller")]
    [ApiController]
    [Authorize(Roles = "Seller")]
    public class SellerPanelController : ControllerBase
    {

    }
}
