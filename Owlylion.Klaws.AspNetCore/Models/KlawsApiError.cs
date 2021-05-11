namespace Owlylion.Klaws.Web.Models
{
    public class KlawsApiError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public KlawsApiError(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
