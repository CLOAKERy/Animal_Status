using System;
using System.Collections.Generic;
using Animal_Status.Models;

namespace Animal_Status
{
    public class AccountViewModel
    {
        public RegisterViewModel registerViewModel { get; set; } = null;
        public LoginViewModel loginViewModel { get; set; } = null;

        public string Code { get; set; } = null;
        public string CodeFromForm { get; set; } = null;
    }
}
