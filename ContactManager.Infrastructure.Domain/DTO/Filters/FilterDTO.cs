using  System.Collections.Generic;

namespace ContactManager.Infrastructure.Domain.DTO.Filters
{
    public class FilterDTO
    {
        public string Name { get; set; }

        public List<int> Applications { get; set; }
    }
}