using System;
using System.Collections.Generic;
using System.Text;
using APIBrumadinho;
using APIBrumadinho.API;
using Xunit;

namespace APITest
{
    public class Linkedin
    {
        readonly LinkedinApi api = LinkedinApi.Current;

        [Fact]
        public void GetTheAuthUrl()
        {
            var answer = string.Format(
            "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id={0}&redirect_uri={1}&state=DCEeFWf45A53sdfKef424scope=r_basicprofile",
            LinkedinEndPoints.ClientId,
            LinkedinEndPoints.REDIRECTURL);

            var result = api.AuthUrl();

            Assert.Equal(answer, result);
        }

        [Theory]
        [InlineData("asdf23XCzqq", "aswoXSSSa12345")]
        [InlineData("", "")]
        [InlineData("", "aswoXSSSa12345")]
        [InlineData("asdf23XCzqq", "")]
        public void InitTest(string clientId, string clientSecret)
        {
            api.Init(clientId, clientSecret);

            Assert.Equal(LinkedinEndPoints.ClientId, clientId);
            Assert.Equal(LinkedinEndPoints.ClientSecret, clientSecret);
        }
    }
}
