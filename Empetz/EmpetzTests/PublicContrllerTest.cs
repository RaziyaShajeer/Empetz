using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading;
using Empetz.API.Public.RequestObject;
using EmpetzTests.Fixtures;

namespace EmpetzTests
{
    public class PublicContrllerTest
	{
		protected readonly HttpClient _httpClient;

		public PublicContrllerTest()
		{
			ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
			_httpClient = _factory.CreateClient();
		}

		[Fact]
		public async Task POST_Register_user_without_phone_Results_BadRequest()
		{
			//Arrange
			UserSignUp user = new UserSignUp();
			user.firstName = "Test";
			user.phone = "";
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("user/signup", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

		}
		[Fact]
		public async Task POST_Register_user_without_phone_and_name_Results_BadRequest()
		{
			//Arrange
			UserSignUp user = new UserSignUp();
			user.firstName = "";
			user.phone = "";
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


			//Act
			var response = await _httpClient.PostAsync("user/signup", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

		}
		[Fact]
		public async Task POST_Register_user_without_Name_Results_BadRequest()
		{
			UserSignUp user = new UserSignUp();
			user.firstName = "";
			user.phone = "9087654321";
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			//Act
			var response = await _httpClient.PostAsync("user/signup", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

		}
		[Fact]
		public async Task POST_Register_user_Results_Success()
		{
			UserSignUp user = new UserSignUp();
			user.firstName = "Veni";
			user.phone = "9087654321";
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			//Act
			var response = await _httpClient.PostAsync("user/signup", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

		}
		[Fact]
		public async Task POST_Login_User_Result_Success()
		{
			LoginRequest loginRequest = new LoginRequest();
			loginRequest.phone = "56456546654";
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			//Act
			var response = await _httpClient.PostAsync("user/Login", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
		[Fact]
		public async Task POST_Login_User_Without_Number_Result_Success()
		{
			LoginRequest loginRequest = new LoginRequest();
			loginRequest.phone = "";
			HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			//Act
			var response = await _httpClient.PostAsync("user/Login", httpContent);
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}



	}
}
