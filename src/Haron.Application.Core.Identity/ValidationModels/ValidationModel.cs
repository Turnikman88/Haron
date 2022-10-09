namespace Haron.Application.Core.Identity.ValidationModels
{
    public class ValidationModel
    {
        public bool Succeeded => !string.IsNullOrWhiteSpace(Message);

        public string? Message { get; set; }
    }
}