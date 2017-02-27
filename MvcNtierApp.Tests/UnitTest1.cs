using System.Web.Mvc;
using MvcNtierApp.Controllers;
using System.Collections;
using System.Data.SqlClient;
using MvcNtierApp.Dal;
using Xunit;
using Assert = Xunit.Assert;

namespace MvcNtierApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Index()
        {
            // Arrange
            TicketsController controller = new TicketsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void MatchModelItemCount()
        {
            // Arrange
            TicketsController controller = new TicketsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var modelItemCount = ((IList)result.ViewData.Model).Count;

            // Assert
            Assert.Equal(8, modelItemCount);
        }

        [Fact]
        public void ConnectionStringNotNull()
        {
            // Arrange
            DataContext dataContext = new DataContext();

            // Act
            SqlConnection connection = dataContext.DbConnection();

            // Assert
            Assert.NotNull(connection);
        }
    }
}
