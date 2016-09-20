using System;
using System.Linq.Expressions;

using Linkedin.Models;
using System.ComponentModel.DataAnnotations;

namespace Linkedin.Web.ViewModels
{
    public class CertificationViewModel
    {
        public static Expression<Func<Certification, CertificationViewModel>> GetCertificationViewModel
        {
            get
            {
                return x => new CertificationViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    LicenseNumber = x.LicenseNumber,
                    Url = x.Url,
                    DateTaken = x.DateTaken,
                    ExpirationDate = x.ExpirationDate
                };
            }
        }

        public long Id { get; set; }

        [Display(Name = "Certificate name")]
        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime DateTaken { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}