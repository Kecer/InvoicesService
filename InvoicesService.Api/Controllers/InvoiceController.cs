using System.Threading.Tasks;
using InvoicesService.Core.Enums;
using InvoicesService.Core.Interfaces.Services;
using InvoicesService.Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InvoicesService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController:ControllerBase
    {
        protected IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] InvoiceProcessingStatus status, [FromQuery] InvoicePaymentMethods paymentMethod, [FromQuery] string order = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var invoices =  await  _invoiceService.ListWithPagging(status,paymentMethod,order, pageNumber, pageSize);

            return new OkObjectResult(invoices);
        }

        [HttpGet]
        [Route("{invoiceNumber}")]
        public async Task<IActionResult> GetByNumber([FromRoute] string invoiceNumber)
        {
            var invoice = await _invoiceService.GetById(invoiceNumber);
            if (!invoice.Succeeded)
            {
                return new NotFoundObjectResult(invoice);
            }

            return new OkObjectResult(invoice);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostInvoiceDto dto)
        {
            var invoice = await _invoiceService.Create(dto);
            return new OkObjectResult(invoice);
        }
        
        [HttpPut]
        [Route("{invoiceNumber}")]
        public async Task<IActionResult> Put([FromRoute] string invoiceNumber,[FromBody] PutInvoiceDto dto)
        {
            var invoice = await _invoiceService.Update(invoiceNumber,dto);
            if (!invoice.Succeeded)
            {
                return new NotFoundObjectResult(invoice);
            }

            return new OkObjectResult(invoice);
        }
    }
}