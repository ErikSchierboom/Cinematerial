namespace Cinematerial.Tests
{
    using System;
    using Xunit;

    public class CinematerialTests
    {
        private const string ApiKey = "test-api-key";
        private const string ApiSecret = "test-api-secret";
        private const string ImdbMovieUrl = "http://www.imdb.com/title/tt1234567/";
        private const int ImageWidth = 300;

        [Fact]
        public void ConstructorWithNullApiKeyThrowsArgumentNullException()
        {
            // Arrange
            string nullApiKey = null;

            // Act
            
            // Assert
            Assert.Throws<ArgumentNullException>(() => new CinematerialService(nullApiKey, "api secret"));
        }

        [Fact]
        public void ConstructorWithEmptyApiKeyThrowsArgumentNullException()
        {
            // Arrange
            var emptyApiKey = string.Empty;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new CinematerialService(emptyApiKey, "api secret"));
        }

        [Fact]
        public void ConstructorWithNullApiSecretThrowsArgumentNullException()
        {
            // Arrange
            string nullApiSecret = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new CinematerialService("api key", nullApiSecret));
        }

        [Fact]
        public void ConstructorWithEmptyApiSecretThrowsArgumentNullException()
        {
            // Arrange
            var emptyApiSecret = string.Empty;

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => new CinematerialService("api key", emptyApiSecret));
        }

        [Theory]
        [InlineData("http://www.imdb.com/")]
        [InlineData("http://www.imdb.com/list/PQDCzc8WwVQ/")]
        [InlineData("http://www.imdb.com/search/title?genres=drama&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/search/title?release_date=1990,1999&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/chart/top/")]
        [InlineData("http://www.imdb.com/boxoffice/alltimegross?region=world-wide")]
        [InlineData("http://www.imdb.com/user/ur3342822/ratings")]
        [InlineData("http://www.google.com")]
        public void SearchUsingImdbMovieUrlWithInvalidImdbMovieUrlThrowsArgumentException(string invalidImdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => cinematerialService.Search(new Uri(invalidImdbMovieUrl)));
        }

        [Theory]
        [InlineData("http://www.imdb.com/")]
        [InlineData("http://www.imdb.com/list/PQDCzc8WwVQ/")]
        [InlineData("http://www.imdb.com/search/title?genres=drama&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/search/title?release_date=1990,1999&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/chart/top/")]
        [InlineData("http://www.imdb.com/boxoffice/alltimegross?region=world-wide")]
        [InlineData("http://www.imdb.com/user/ur3342822/ratings")]
        [InlineData("http://www.google.com")]
        public void SearchUsingImdbMovieUrlAndImageWidthWithInvalidImdbMovieUrlThrowsArgumentException(string invalidImdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => cinematerialService.Search(new Uri(invalidImdbMovieUrl), ImageWidth));
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt123456/")]
        [InlineData("http://www.imdb.com/title/tt1/")]
        [InlineData("http://www.imdb.com/title/tt/")]
        [InlineData("http://www.imdb.com/title/")]
        [InlineData("http://www.imdb.com/title")]
        public void SearchUsingImdbMovieUrlWithIncompleteImdbMovieUrlThrowsArgumentException(string incompleteImdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => cinematerialService.Search(new Uri(incompleteImdbMovieUrl)));
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt123456/")]
        [InlineData("http://www.imdb.com/title/tt1/")]
        [InlineData("http://www.imdb.com/title/tt/")]
        [InlineData("http://www.imdb.com/title/")]
        [InlineData("http://www.imdb.com/title")]
        public void SearchUsingImdbMovieUrlAndImageWidthWithIncompleteImdbMovieUrlThrowsArgumentException(string incompleteImdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => cinematerialService.Search(new Uri(incompleteImdbMovieUrl), ImageWidth));
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(0)]
        [InlineData(29)]
        [InlineData(301)]
        [InlineData(500)]
        public void SearchUsingImdbMovieUrlAndImageWidthOutOfRangeThrowsArgumentOutOfRangeException(int invalidImageWidth)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cinematerialService.Search(new Uri(ImdbMovieUrl), invalidImageWidth));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-300)]
        public void SearchUsingImdbMovieIdWithImdbMovieIdOutOfRangeThrowsArgumentOutOfRangeException(int invalidImdbMovieId)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cinematerialService.Search(invalidImdbMovieId));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-300)]
        public void SearchUsingImdbMovieIdAndImageWidthWithImdbMovieIdOutOfRangeThrowsArgumentOutOfRangeException(int invalidImdbMovieId)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cinematerialService.Search(invalidImdbMovieId, ImageWidth));
        }

        [Fact]
        public void GetApiUrlUsingNullImdbMovieUrlThrowsArgumentNullException()
        {
            // Arrange
            Uri nullImdbMovieUrl = null;
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => cinematerialService.GetApiUrl(nullImdbMovieUrl, ImageWidth));
        }

        [Theory]
        [InlineData("http://www.google.nl")]
        [InlineData("http://www.imdb.com")]
        [InlineData("http://www.imdb.com/chart/top")]
        [InlineData("http://www.imdb.com/list/PQDCzc8WwVQ/")]
        [InlineData("http://www.imdb.com/user/ur3342822/ratings")]
        public void GetApiUrlUsingInvalidImdbMovieUrlThrowsArgumentException(string invalidImdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => cinematerialService.GetApiUrl(new Uri(invalidImdbMovieUrl), ImageWidth));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-300)]
        public void GetApiUrlUsingImdbMovieIdOutOfRangeThrowsArgumentOutOfRangeException(int invalidImdbMovieId)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => cinematerialService.GetApiUrl(invalidImdbMovieId, ImageWidth));
        }
    }
}