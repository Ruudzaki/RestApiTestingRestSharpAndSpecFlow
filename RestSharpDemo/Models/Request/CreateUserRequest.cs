using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpDemo.Models.Request
{
    public class CreateUserRequest
    {
        public string name { get; set; }
        public string job { get; set; }
    }

}
