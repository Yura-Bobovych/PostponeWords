using System;
using System.Collections.Generic;

namespace PostponeWords.Data.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Hesh { get; set; }
    }
}
