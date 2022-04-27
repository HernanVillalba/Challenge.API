using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChallengeTesting.Services.DataLake
{
    [TestClass]
    public class ExampleTest
    {
        //private readonly IService Service;

        public ExampleTest()
        {
            //var serviceProvider = ServiceBuilder.BuildServiceProvider();

            // service = serviceProvider.GetService<IStgMagaluDataLakeService>();
        }

        [TestMethod]
        public async Task TestMethod()
        {
            // Arrange
            HttpClient client = new();

            // Act
            using HttpResponseMessage response = await client.GetAsync("https://pokeapi.co/api/v2/pokemon/pikachu");

            // Assert
            HttpStatusCode statusCode = response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }
    }
}