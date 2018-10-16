using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJobStarterPack.Web.ViewModels.Security
{
    public class UsernamePasswordLoginModel
    {
        public UsernamePasswordLoginModel()
        {
            Errors = new List<string>();
        }

        public string UserName { get; set; }

        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        public string RedirectToUrl { get; set; }

        public List<String> Errors
        {
            get;
            set;
        }

        public bool HasErrors
        {
            get
            {
                return Errors != null && Errors.Any();
            }
        }
    }
}
