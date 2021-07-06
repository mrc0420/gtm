using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationPrototype.Controllers.Helper;
using RegistrationPrototype.Domain.Abstract.Service.Entity;
using RegistrationPrototype.ViewModels;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace RegistrationPrototype.Controllers.API
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;

        }

        // POST: ai/Users
        [HttpPost("registration")]
        public IActionResult Registration([FromBody] UserViewModel model)
        {
            try
            {
                var result = this.userService.Registration(model.ToUserDomain());
                return Ok(result);
            }

            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        [HttpPost("login")]
        public IActionResult IsAuthorise([FromBody] LoginViewModel model)
        {
            try
            {
                return Ok(this.userService.IsAuthorise(model.Email, model.Password));
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        //[HttpPost("upload/image")]
        //public IActionResult UploadImage([FromBody]string image)
        //{
        //    try
        //    {
        //        var result = image;
        //        return Ok(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentNullException(ex.Message);
        //    }
        //}
        //[HttpPost("upload/image"), DisableRequestSizeLimit]
        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);

        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }

        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        [HttpPost("personel-details/update")]
        //[Consumes("multipart/form-data")]
        public IActionResult UpdatePersonelDetails([FromForm] PersonelDetailsViewModel model)
        {
            var personelData = model.ToPersonelDetailsDomain();
            return Ok(this.userService.PersonelDetails(personelData));

        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
