using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SeekQ.NotificationsAndModesSettings.Api.Application.Queries;
using SeekQ.NotificationsAndModesSettings.Api.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SeekQ.NotificationsAndModesSettings.Api.Test
{
    public class NotificationsControllerTest: BaseIntegrationTest<Startup>
    {
        public NotificationsControllerTest(WebApplicationFactory<Startup> factory) 
            : base(factory)
        {

        }

        [Fact]
        public async void GetNotificationsByUser_GetExpectedNotificationsList()
        {

            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync($"api/v1/notifications/user/{NotificationsModesSettingsSeeding.ID_USER_JOSE}");

            // Assert
            response.EnsureSuccessStatusCode();
            var notificationsSettingsList = JsonConvert
                               .DeserializeObject<IEnumerable<GetNotificationsByUserViewModel>>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(notificationsSettingsList.Count() == 2, "Courses list where not loaded");
        }
    }
}
