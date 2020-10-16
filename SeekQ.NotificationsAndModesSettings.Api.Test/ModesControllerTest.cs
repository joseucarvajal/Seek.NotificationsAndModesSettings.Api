using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SeekQ.NotificationsAndModesSettings.Api.Application.Queries;
using SeekQ.NotificationsAndModesSettings.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SeekQ.NotificationsAndModesSettings.Api.Test
{
    public class ModesControllerTest : BaseIntegrationTest<Startup>
    {
        public ModesControllerTest(WebApplicationFactory<Startup> factory)
            : base(factory)
        {

        }

        [Fact]
        public async void GetModesByUser_GetExpectedModesList()
        {

            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync($"api/v1/modes/user/{NotificationsModesSettingsSeeding.ID_USER_DANIEL}");

            // Assert
            response.EnsureSuccessStatusCode();
            var notificationsSettingsList = JsonConvert
                               .DeserializeObject<IEnumerable<GetModesByUserViewModel>>
                                   (await response.Content.ReadAsStringAsync());

            Assert.True(notificationsSettingsList.Count() == 1, "Modes list where not loaded");
        }
    }
}
