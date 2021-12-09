using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto._Base
{
    public class ApplicationSettingsDto
    {
        public ConnectionString ConnectionStrings { get; set; }
        public string JiraToken { get; set; }
        public string AuthenticationServer { get; set; }
    }

    public class ConnectionString
    {
        public string MySql { get; set; }
        public string Vtas { get; set; }

    }
}
