    public class CustomerController : ApiController
    {
        public IHttpActionResult Get()
        {
            var customresult = new CacheableHttpActionResult<Customer>(Request, 
                new Customer() { CustomerId = 1, Name = "Thuru" }, 5);
            return customresult;
        }
    }
