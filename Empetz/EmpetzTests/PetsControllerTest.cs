using Empetz.API.Pets.RequestObject;
using Empetz.API.Public.RequestObject;
using Empetz.API.User.RequestObject;
using EmpetzTests.Fixtures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmpetzTests
{
	public class PetsControllerTest
	{
		protected readonly HttpClient _httpClient;

		public PetsControllerTest(HttpClient httpClient)
		{
			ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
			_httpClient = _factory.CreateClient();
		}
		[Fact]
		public async Task GET_Pets_by_BreeId_ResultSuccess()
		{
			var breedid = "3fa85f64-5717-4562-b3fc-2c963f66afa3";
			//Act
			var response = await _httpClient.GetAsync("Pets/{breedid}/Pets");
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);


		}
		public async Task GET_Pets_by_InvalidBreeId_ResultSuccess()
		{
			var breedid = "3fa85f64-5717-4562-b3fc-2c9";
			//Act
			var response = await _httpClient.GetAsync("Pets/{breedid}/Pets");
			//Assert
			Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);


		}
		public async Task GET_Pets_by_EmptyId_ResultSuccess()
		{
			var breedid = Guid.Empty;
			//Act
			var response = await _httpClient.GetAsync("Pets/{breedid}/Pets");
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task Post_Pet_Return_Success()
		{
			PetPost pet = new PetPost("Lucy", new Guid("3fa85f64-5717-4562-b3fc-2c9"), 4, "Good", "Female", new Guid("3fa85f64-5717-4562-b3fc-2c9"), "hdfg.Japg", new Guid("3fa85f64-5717-4562-b3fc-2c9"));
			
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			var response = await _httpClient.PostAsync("Pets/Addpet", httpContent);
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);


		}
		[Fact]
		public async Task Post_Pet_With_Empty_Discription_return_BadRequest()
		{
			PetPost pet = new PetPost("Lucy", new Guid("3fa85f64-5717-4562-b3fc-2c9"), 4, " ", "Female", new Guid("3fa85f64-5717-4562-b3fc-2c9"), "hdfg.Japg", new Guid("3fa85f64-5717-4562-b3fc-2c9"));
			
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			var response = await _httpClient.PostAsync("Pets/Addpet", httpContent);
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task Post_Pet_With_Empty_CategoryId_return_BadRequest()
		{
			PetPost pet = new PetPost("Lucy", new Guid("3fa85f64-5717-4562-b3fc-2c9"), 4, "", "Female",Guid.Empty, "hdfg.Japg", new Guid("3fa85f64-5717-4562-b3fc-2c9"));

			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			var response = await _httpClient.PostAsync("Pets/Addpet", httpContent);
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task Post_Pet_With_Empty_UserId_return_BadRequest()
		{
			PetPost pet = new PetPost("Lucy", new Guid("3fa85f64-5717-4562-b3fc-2c9"), 4, "", "Female", new Guid("3fa85f64-5717-4562-b3fc-2c9"), "hdfg.Japg",Guid.Empty);

			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(pet), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			var response = await _httpClient.PostAsync("Pets/Addpet", httpContent);
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task GET_Pet_by_PetId_ResultSuccess()
		{
			var petid = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
			//Act
			var response = await _httpClient.GetAsync("Pets/{petid}/Pet");
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);


		}
		[Fact]
		public async Task GET_Pet_by_InvalidPetId_ResultBadRequest()
		{
			var petid = "3fa85f64-5717-4562-b3fc-2c963f66";
			//Act
			var response = await _httpClient.GetAsync("Pets/{petid}/Pet");
			//Assert
			Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);


		}
	}
}
