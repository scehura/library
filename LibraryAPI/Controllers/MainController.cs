using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers {
    public class MainController: ControllerBase {
        
        [HttpGet("/")]
        public object Main() {
            return new { name = "LibraryAPI" };
        }
    }
}