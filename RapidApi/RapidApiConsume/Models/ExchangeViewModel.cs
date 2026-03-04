namespace RapidApiConsume.Models
{
    public class ExchangeViewModel
    {
        public class ExchangeResponse
        {
            public bool status { get; set; }
            public string message { get; set; }
            public ExchangeViewModel data { get; set; }
        }

        public Exchange_Rates[] exchange_rates { get; set; }
        public string base_currency_date { get; set; }
        public string base_currency { get; set; }

        public class Exchange_Rates
        {
            public string currency { get; set; }
            public string exchange_rate_buy { get; set; }
        }



    }
}
