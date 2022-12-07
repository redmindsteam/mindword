using MindWord.Service.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.UnitTest.Services.Attirbutes
{
    public class PasswordAttirbute
    {
        StrongPasswordAttribute passwordAttribute = new StrongPasswordAttribute();

        [Theory]
        [InlineData("123456As")]
        [InlineData("111111Ic")]
        [InlineData("Ali21092")]
        [InlineData("Azizbek01")]
        [InlineData("Quvond1q")]
        public void ReturnTrue(string password)
        {
            var result = passwordAttribute.IsStrong(password);
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("12345678")]
        [InlineData("Qahhorbek")]
        [InlineData("normadjon")]
        [InlineData("quvond1q")]

        public void ReturnFalse(string password) 
        {
            var result = passwordAttribute.IsStrong(password);
            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData("123456789As")]
        [InlineData("qertyutr12A")]
        [InlineData("Fazliddin21")]
        [InlineData("Normadjon1")]
        [InlineData("Quvondiq01")]

        public void ReturnTrueLenth(string password)
        {
            var result = passwordAttribute.IsValid(password);
            Assert.True(result.isSuccessful);
        }


        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("a")]
        [InlineData("qws")]
        public void ReturnFalseLenth(string password)
        {
            var result = passwordAttribute.IsValid(password);
            Assert.False(result.isSuccessful);
        }
    }
}
