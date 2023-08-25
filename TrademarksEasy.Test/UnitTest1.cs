using TrademarksEasy.Services;

namespace TrademarksEasy.Test
{
    public class TrademarkServiceTest
    {
        private readonly TrademarksService _trademarksService;
        public TrademarkServiceTest()
        {
            _trademarksService = new TrademarksService();
        }
        [Fact]
        public void New_trademark_yandex_is_registred()
        {
            //Arrange
            var trademark = "yandex";
            //Action
            var result = _trademarksService.TryAdd(trademark);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Registration_of_existed_trademark_is_rejected()
        {
            var trademark = "yandex";
            _trademarksService.TryAdd(trademark);

            var result = _trademarksService.TryAdd(trademark);

            Assert.False(result);
        }

        //TODO: 
    }
}