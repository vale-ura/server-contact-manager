using System;
using System.Collections.Generic;
using ContactManager.Infrastructure.Domain.DTO.Application;

namespace ContactManager.Infrastructure.Domain.DTO.Contact
{
    public class ContactDTO
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public IList<ApplicationDTO> Applications { get; set; }
    }
}