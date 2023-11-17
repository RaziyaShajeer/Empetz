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
	public class UserControllerTest
	{
		protected readonly HttpClient _httpClient;

		public UserControllerTest(HttpClient httpClient)
		{
			ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
			_httpClient = httpClient;
		}
		[Fact]
		public async Task Post_Pets_To_Wishlist_ResultSuccess()
		{
			Wishlistrequest wishlistobject = new Wishlistrequest();
			wishlistobject.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
			wishlistobject.PetId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(wishlistobject), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			var response = await _httpClient.PostAsync("wishlist/add", httpContent);
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);


		}
		[Fact]
		public async Task Post_Pets_To_Wishlist_WithEmpty_userId_and_petId_ResultBadRequest()
		{
			Wishlistrequest wishlistobject = new Wishlistrequest();
			wishlistobject.UserId = Guid.Empty;
			wishlistobject.PetId = Guid.Empty;
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(wishlistobject), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			var response = await _httpClient.PostAsync("wishlist/add", httpContent);
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task Post_Pets_To_Wishlist_With_invalid_userId_ResultBadRequest()
		{
			Wishlistrequest wishlistobject = new Wishlistrequest();
			wishlistobject.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66a");
			wishlistobject.PetId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(wishlistobject), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			
			var response = await _httpClient.PostAsync("wishlist/add", httpContent);
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

		}
		[Fact]
		public async Task Post_Pets_To_Wishlist_With_invalid_petId_ResultBadRequest()
		{
			Wishlistrequest wishlistobject = new Wishlistrequest();
			wishlistobject.UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66a");
			wishlistobject.PetId = new Guid("3fa85f64-5717-4562-b3fc-963f66afa");
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(wishlistobject), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			var response = await _httpClient.PostAsync("wishlist/add", httpContent);
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task Get_Wishlist_With_valid_userId_return_Sucess()
		{
			var userId = "3fa85f64-5717-4562-b3fc-2c963f66afa";
			
			var response = await _httpClient.GetAsync("users/{userId}/wishlist");
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
		[Fact]
		public async Task Get_Wishlist_With_Invalid_userId_return_BadRequest()
		{
			var userId = "3fa85f64-5717-4562-b3fc-2c963f66afa";

			var response = await _httpClient.GetAsync("users/{userId}/wishlist");
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task Get_Wishlist_With_Empty_userId_return_BadRequest()
		{
			var userId = "3fa85f64-5717-4562-b3fc-2c963f66afa";

			var response = await _httpClient.GetAsync("users/{userId}/wishlist");
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}




	}
}
