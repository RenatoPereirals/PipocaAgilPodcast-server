namespace PipocaAgilPodcast.Services;

    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
