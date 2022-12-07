using MindWord.Service.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.UnitTest.Services.Attirbutes
{
    public class EmailAttirbuteTest
    {
        [Theory]
        [InlineData("aziz@gmail.com")]
        [InlineData("ali@gmail.com")]
        [InlineData("Quvondiq@gmail.com")]
        [InlineData("Normadjon@gmail.com")]
        [InlineData("Qahhor@gmail.com")]
        public void ReturnTrue(string email)
        {
            EmailAttribute emailAttirbute = new  MindWord.Service.Attributes.EmailAttribute();
            var result = emailAttirbute.IsValid(email);
            Assert.True(result.isSuccessful);
        }
        [Theory]
        [InlineData("a@gmail.com")]
        [InlineData("aziz")]
        [InlineData("Quvondiq")]
        [InlineData("Normadjon")]
        [InlineData("Qahhor")]
        public void ReturnFalse(string email)
        {

            EmailAttribute emailAttirbute = new MindWord.Service.Attributes.EmailAttribute();
            var result = emailAttirbute.IsValid(email);
            Assert.False(result.isSuccessful);
        }
    }
}
