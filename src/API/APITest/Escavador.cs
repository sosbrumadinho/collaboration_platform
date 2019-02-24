using System;
using System.Threading.Tasks;
using APIBrumadinho.API;
using APIBrumadinho.Helpers;
using APIBrumadinho.Models;
using Xunit;

namespace APITest
{
    public class Escavador
    {
        // Reference: https://youtu.be/ub3P8c87cwk

        [Fact]
        public async Task AuthEscavadorSuccessAsync()
        {
            // Arrange
            var answer = Result.Success(true);

            // Act
            var api = await InitApi(string.Empty, string.Empty, true);

            var result = await api.AuthAsync();

            // Assert
            Assert.Equal(answer, result);
        }

        [Fact]
        public async Task SuccessGetCreditsAsync()
        {
            var answer = Result.Success("12");

            var api = await InitApi(string.Empty, string.Empty);

            var result = await api.GetCreditsAsync();

            Assert.Equal(answer, result);
            Assert.True(int.TryParse(result.Value, out _));
        }

        [Fact]
        public async Task SuccessSearchPeopleIdAsync()
        {
            var answer = Result.Success(new PeopleResult());

            var api = await InitApi(string.Empty, string.Empty);

            var result = await api.SearchPeopleAsync(2);

            Assert.Equal(answer, result);
            Assert.Equal(typeof(PeopleResult), result.Value?.GetType());
        }

        [Theory]
        [InlineData("", "1234")]
        [InlineData("", "")]
        [InlineData("teste@gmail.com", "1234")]
        [InlineData("teste@gmail.com", "")]
        public async Task AuthEscavadorFail(string user, string pass)
        {
            var answer = Result.Fail<bool>("Error");

            var api = await InitApi(user, pass, true);
            var result = await api.AuthAsync();

            Assert.Equal(answer, result);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public async Task SearchPeopleAsyncFail(int id)
        {
            var answer = Result.Fail<PeopleResult>("Can't get the people", default);

            var api = await InitApi(string.Empty, string.Empty);
            var result = await api.SearchPeopleAsync(id);

            Assert.Equal(answer, result);
        }

        async Task<EscavadorApi> InitApi(string user, string password, bool isAuth = false)
        {
            var api = EscavadorApi.Current;
            api.Init(user, password, APIBrumadinho.Logger.LogLevel.None);

            if (!isAuth)
                await api.AuthAsync();

            return api;
        }
    }
}
