using System;

namespace Munizoft.Identity.Infrastructure.Models
{
    public class ServiceError
    {
        public String Code { get; set; }
        public String Description { get; set; }

        public ServiceError(String description)
            : this(String.Empty, description)
        {

        }

        public ServiceError(String code, String description)
        {
            Code = code;
            Description = description;
        }
    }
}