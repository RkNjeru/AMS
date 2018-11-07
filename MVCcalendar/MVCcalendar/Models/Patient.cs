using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;


namespace MVCcalendar.Models
{
    //[Table("Patients")]
    public class Patient /*: PageModel*/
    {
        public string Name { get; set; }
        //[Required(ErrorMessage ="Enter name")]

        public string Email { get; set; }
        //[Required(ErrorMessage ="Enter email")]
        public string Address { get; set; }
        //[Required(ErrorMessage ="Enter address")]
        public string Phone { get; set; }
        //[Required(ErrorMessage ="Enter phone number")]

    }
}