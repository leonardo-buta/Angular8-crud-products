using System.Collections.Generic;

namespace Products.Domain.DTO
{
    public class PaginationResultDTO<T> where T : class
    {
        public IEnumerable<T> Result { get; set; }
        public int CollectionSize { get; set; }
        public int PageSize
        {
            get { return 8; }
        }
    }
}
