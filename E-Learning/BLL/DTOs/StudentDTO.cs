﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentDTO
    {
        public int Id { set; get; }
        public string fname { set; get; }
        public string lname { set; get; }
        public string email { set; get; }
        public string age { set; get; }
        public int PId { get; set; }
        
    }
}
