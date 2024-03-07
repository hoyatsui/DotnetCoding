using DotnetCoding.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotnetCoding.Core.Models;
namespace DotnetCoding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _requestService.GetAllRequests();
            return Ok(requests);
        }

        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveRequest(int id)
        {
            try
            {
                await _requestService.ApproveRequest(id);
                return Ok($"Request {id} approved.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectRequest(int id)
        {
            try
            {
                await _requestService.RejectRequest(id);
                return Ok($"Request {id} rejected.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            await _requestService.DeleteRequest(id);
            return Ok($"Request {id} deleted.");
        }
    }
}
