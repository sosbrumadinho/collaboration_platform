using System;
using System.Collections.Generic;
using System.Text;
using APIBrumadinho;
using Xunit;

namespace APITest
{
    public class Linkedin
    {
        [Fact]
        public void GetTheAuthUrl()
        {
            var answer = string.Format(
            "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id={0}&redirect_uri={1}&state=DCEeFWf45A53sdfKef424scope=r_basicprofile",
            LinkedinEndPoints.ClientId,
            LinkedinEndPoints.REDIRECTURL);

            var result = APIBrumadinho.API.LinkedinApi.Current.AuthUrl();

            Assert.Equal(answer, result);
        }
    }
}
