﻿using Microsoft.AspNetCore.Http;

namespace HrApp.Application;

public class AppUserUpdateDto
{
   //TODO : Daha sonra kontrol et
   public string Id { get; set; }
   public IFormFile Image { get; set; }
   public string Address { get; set; }
   public string MobileNumber { get; set; }
}
