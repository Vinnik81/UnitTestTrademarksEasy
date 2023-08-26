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
            //Arrange
            var trademark = "yandex";
            _trademarksService.TryAdd(trademark);
            //Action
            var result = _trademarksService.TryAdd(trademark);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IgnoreCase_CorrectlyIgnoresCase()
        {
            //Arrange
            var trademark = "Yandex";
            //Action
            var result1 = _trademarksService.TryAdd(trademark);
            var result2 = _trademarksService.TryAdd(trademark.ToLower());
            //Assert
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void IgnoreSpaces_CorrectlyIgnoresSpaces()
        {
            //Arrange
            var trademark1 = "y ande x";
            var trademark2 = "yandex";
            //Action
            var result1 = _trademarksService.TryAdd(trademark1);
            var result2 = _trademarksService.TryAdd(trademark2);
            //Assert
            Assert.True(result1);
            Assert.False(result2);
        }

    }
}