﻿using Bespoke.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bespoke.Web.Model
{
    public class BranchModel
    {
        public Branch Branch { get; set; }

        public List<Branch> Branches { get; set; }

        public string Message { get; set; }
    }
}