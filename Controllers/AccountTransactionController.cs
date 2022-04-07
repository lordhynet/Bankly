using BANKLYFINANCIALAPP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransactionController : ControllerBase
    {
        private readonly IUserTransactionService _transService;
        public AccountTransactionController(IUserTransactionService transService)
        {
            _transService = transService;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("user-transactions/{userId}")]
        public async Task<IActionResult> GetAllUserTransaction(string userId)
            => Ok(await _transService.GetTransactionsByUserID(userId));

        [HttpGet("get-transactions-as-pdf/{userId}")]

        public async Task<FileResult> DownloadAsPdf(string userId)
        {
            var path = await _transService.GetTransactionsAsPdf(userId);
            var file = System.IO.File.ReadAllBytes(path);
            return File(file, System.Net.Mime.MediaTypeNames.Application.Octet, "statement.txt");
        }

        [HttpGet("files/{id:int}")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            var filePath = $"{id}.pdf"; // Here, you should validate the request and the existance of the file.

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, "text/plain", Path.GetFileName(filePath));
            // ... code for validation and get the file

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            //var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}
