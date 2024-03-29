﻿using System;
using System.Collections.Generic;

#nullable disable

namespace API_Test.Database.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
