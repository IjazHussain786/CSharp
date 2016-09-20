using System.ComponentModel.DataAnnotations.Schema;

namespace Linkedin.Models
{
    [ComplexType]
    public class ContactInfo
    {
        public string Phone { get; set; }

        public string Twitter { get; set; }

        public string Website { get; set; }

        public string Facebook { get; set; }
    }
}
