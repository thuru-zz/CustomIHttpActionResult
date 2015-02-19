    public class CacheableHttpActionResult<T> : IHttpActionResult
    {
        private T content;
        private int cacheTimeInMin;
        private HttpRequestMessage request;

        public CacheableHttpActionResult(HttpRequestMessage request, T content, int cachetime)
        {
            this.content = content;
            this.request = request;
            this.cacheTimeInMin = cachetime;
        }

        public System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = request.CreateResponse<T>(HttpStatusCode.OK, this.content);
            response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue() 
            {
                MaxAge = TimeSpan.FromMinutes(this.cacheTimeInMin),
                // other customizations
            };
            
            return Task.FromResult(response);
        }
    }
