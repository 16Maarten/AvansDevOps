namespace AvansDevOps.Tests.Domain.Persons
{
    public class DeveloperTests
    {
        [Fact]
        public void Test_AddContactPreference()
        {
            // Arrange
            var developer = new Developer("dev");
            developer.ContactPreferences.Clear();

            // Act
            developer.AddContactPreference(ContactPreference.Slack);

            // Assert
            Assert.Contains(ContactPreference.Slack, developer.ContactPreferences);
        }

        [Fact]
        public void Test_RemoveContactPreference()
        {
            // Arrange
            var developer = new Developer("dev");

            // Act
            developer.RemoveContactPreference(ContactPreference.Slack);

            // Assert
            Assert.DoesNotContain(ContactPreference.Slack, developer.ContactPreferences);
        }
    }
}
