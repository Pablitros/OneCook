using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneCook.DL.Models.Context.Helper
{
    public class ContextHelper
    {
        public IConfiguration _configuration { get; }

        public ContextHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
