using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpDemo.Models
{

    public class CreateUser
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
    }

}
