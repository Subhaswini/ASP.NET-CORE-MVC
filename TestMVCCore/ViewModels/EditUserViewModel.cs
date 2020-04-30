using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCCore.Models;

namespace TestMVCCore.ViewModels
{
    public class EditUserViewModel
    {
        public WebUser User { get; set; }

        public List<string> Countries { get; set; }
    }
}
