namespace TrademarksEasy.Services
{
    public class TrademarksService
    {
        //потокобезопасность
        private readonly List<string> _trademarks = new List<string>();

        public TrademarksService() 
        {
            _trademarks = new List<string>();
        }

        public virtual bool TryAdd(string trademark)
        {
            if (trademark is null)
            {
                throw new ArgumentNullException(nameof(trademark));
            }

            var normalizedTrademark = NormalizedTrademark(trademark);

            if (_trademarks.Contains(normalizedTrademark)) return false;
                _trademarks.Add(normalizedTrademark);
                return true;
            
        }

        private string NormalizedTrademark(string trademark)
        {
           var result = trademark.ToLower()
                .Replace(" ", "");
            return result;
        }
    }
}
