namespace Products.Domain.Parameters
{
    public class QueryStringParameters
    {
        public int Page { get; set; } = 1;
        public int PageSize
        {
            get { return 8; }
        }
    }
}
