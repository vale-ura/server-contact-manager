using System;
using System.Collections.Generic;
using ContactManager.Infrastructure.Domain.DTO.Application;

namespace ContactManager.Infrastructure.Domain.DTO.Contact
{
    public class ContactDTO
    {
        public string Name { get; set; }

        public List<ApplicationDTO> Applications { get; set; }
    }
}