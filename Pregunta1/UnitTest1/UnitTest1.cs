using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta1.Controllers;
using Pregunta1.Models;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            velascoesController controller = new velascoesController();
            //Act
            var listaPersonas = controller.Getvelascoes();
            //Assert
            Assert.IsNotNull(listaPersonas);
        }
        [TestMethod]
        public void TestPost()
        {
            //Arrange
            velascoesController controller = new velascoesController();
            velasco velasquito = new velasco()
            {
                velascoID = 1,
                Friendofvelasco = "Alberto Marin",
                places = Places.Santa_Cruz,
                Email = "albertomarin@gmail.com",
                Birthdate = DateTime.Now
            };
            //Act
            IHttpActionResult actionResult = controller.Postvelasco(velasquito);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<velasco>;
            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestPut()
        {
            //Arrange
            velascoesController controller = new velascoesController();
            velasco velasquito = new velasco()
            {
                velascoID = 2,
                Friendofvelasco = "Sebastian Ferrufino",
                places = Places.Beni,
                Email = "sebastianferrufino@gmail.com",
                Birthdate = DateTime.Now
            };
            //Act
            IHttpActionResult actionResult = controller.Postvelasco(velasquito);
            var result = controller.Putvelasco(velasquito.velascoID, velasquito) as StatusCodeResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            velascoesController controller = new velascoesController();
            velasco velasquito = new velasco()
            {
                velascoID = 3,
                Friendofvelasco = "Cesar Loayza",
                places = Places.Santa_Cruz,
                Email = "cesarloayza@gmail.com",
                Birthdate = DateTime.Now
            };
            //Act
            IHttpActionResult actionResultPost = controller.Postvelasco(velasquito);
            IHttpActionResult actionResultDelete = controller.Deletevelasco(velasquito.velascoID);
            //Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<velasco>));
        }
    }
}
