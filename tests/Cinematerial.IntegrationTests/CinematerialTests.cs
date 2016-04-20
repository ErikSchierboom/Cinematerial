namespace Cinematerial.IntegrationTests
{
    using System;
    using Xunit;

    public class CinematerialTests
    {
        private const int ImageWidth = 100;
        private const int ImdbMovieIdWithPoster = 1375666;
        private const int ImdbMovieIdWithoutPoster = 196508;

        private static readonly string ApiKey = Configuration.Get("CINEMATERIAL_API_KEY");
        private static readonly string ApiSecret = Configuration.Get("CINEMATERIAL_API_SECRET");
        
        [Fact]
        public void SearchUsingImdbMovieIdForMovieWithPosterWillReturnCorrectcinematerialResult()
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(ImdbMovieIdWithPoster);

            // Assert
            Assert.Equal("Inception", cinematerialResult.Title);
            Assert.Equal("2010", cinematerialResult.Year);
            Assert.Equal("1375666", cinematerialResult.ImdbMovieId);
            Assert.Equal(@"https://api.cinematerial.com/cache/normal/66/tt1375666/447241_300.jpg", cinematerialResult.Posters[0].Url);
            Assert.Equal(1, cinematerialResult.Posters.Length);
        }

        [Fact]
        public void SearchUsingImdbMovieIdForMovieWithoutPosterReturnsNullForProperties()
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(ImdbMovieIdWithoutPoster);

            // Assert
            Assert.Null(cinematerialResult.Title);
            Assert.Null(cinematerialResult.Year);
            Assert.Null(cinematerialResult.ImdbMovieId);
            Assert.Null(cinematerialResult.Page);
            Assert.Null(cinematerialResult.Posters);
        }

        [Fact]
        public void SearchUsingImdbMovieIdAndImageWidthForMovieWithPosterWillReturnCorrectcinematerialResult()
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(ImdbMovieIdWithPoster, ImageWidth);

            // Assert
            Assert.Equal("Inception", cinematerialResult.Title);
            Assert.Equal("2010", cinematerialResult.Year);
            Assert.Equal("1375666", cinematerialResult.ImdbMovieId);
            Assert.Equal(@"https://api.cinematerial.com/cache/normal/66/tt1375666/447241_100.jpg", cinematerialResult.Posters[0].Url);
            Assert.Equal(1, cinematerialResult.Posters.Length);
        }

        [Fact]
        public void SearchUsingImdbMovieIdAndImageWidthForMovieWithoutPosterReturnsNullForProperties()
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(ImdbMovieIdWithoutPoster, ImageWidth);

            // Assert
            Assert.Null(cinematerialResult.Title);
            Assert.Null(cinematerialResult.Year);
            Assert.Null(cinematerialResult.ImdbMovieId);
            Assert.Null(cinematerialResult.Page);
            Assert.Null(cinematerialResult.Posters);
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt1375666")]
        [InlineData("http://www.imdb.com/title/tt1375666/")]
        [InlineData("http://www.imdb.com/title/tt1375666/reference")]
        [InlineData("http://www.imdb.com/title/tt1375666/reference/")]
        public void SearchUsingImdbMovieUrlForMovieWithPosterWillReturnCorrectcinematerialResult(string imdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(new Uri(imdbMovieUrl));

            // Assert
            Assert.Equal("Inception", cinematerialResult.Title);
            Assert.Equal("2010", cinematerialResult.Year);
            Assert.Equal("1375666", cinematerialResult.ImdbMovieId);
            Assert.Equal(@"https://api.cinematerial.com/cache/normal/66/tt1375666/447241_300.jpg", cinematerialResult.Posters[0].Url);
            Assert.Equal(1, cinematerialResult.Posters.Length);
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt0196508")]
        [InlineData("http://www.imdb.com/title/tt0196508/")]
        [InlineData("http://www.imdb.com/title/tt0196508/reference")]
        [InlineData("http://www.imdb.com/title/tt0196508/reference/")]
        public void SearchUsingImdbMovieUrlForMovieWithoutPosterReturnsNullForProperties(string imdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(new Uri(imdbMovieUrl));

            // Assert
            Assert.Null(cinematerialResult.Title);
            Assert.Null(cinematerialResult.Year);
            Assert.Null(cinematerialResult.ImdbMovieId);
            Assert.Null(cinematerialResult.Page);
            Assert.Null(cinematerialResult.Posters);
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt1375666")]
        [InlineData("http://www.imdb.com/title/tt1375666/")]
        [InlineData("http://www.imdb.com/title/tt1375666/reference")]
        [InlineData("http://www.imdb.com/title/tt1375666/reference/")]
        public void SearchUsingImdbMovieUrlAndImageWidthForMovieWithPosterWillReturnCorrectcinematerialResult(string imdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(new Uri(imdbMovieUrl), ImageWidth);

            // Assert
            Assert.Equal("Inception", cinematerialResult.Title);
            Assert.Equal("2010", cinematerialResult.Year);
            Assert.Equal("1375666", cinematerialResult.ImdbMovieId);
            Assert.Equal(@"https://api.cinematerial.com/cache/normal/66/tt1375666/447241_100.jpg", cinematerialResult.Posters[0].Url);
            Assert.Equal(1, cinematerialResult.Posters.Length);
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt0196508")]
        [InlineData("http://www.imdb.com/title/tt0196508/")]
        [InlineData("http://www.imdb.com/title/tt0196508/reference")]
        [InlineData("http://www.imdb.com/title/tt0196508/reference/")]
        public void SearchUsingImdbMovieUrlAndImageWidthForMovieWithoutPosterReturnsNullForProperties(string imdbMovieUrl)
        {
            // Arrange
            var cinematerialService = new CinematerialService(ApiKey, ApiSecret);

            // Act
            var cinematerialResult = cinematerialService.Search(new Uri(imdbMovieUrl), ImageWidth);

            // Assert
            Assert.Null(cinematerialResult.Title);
            Assert.Null(cinematerialResult.Year);
            Assert.Null(cinematerialResult.ImdbMovieId);
            Assert.Null(cinematerialResult.Page);
            Assert.Null(cinematerialResult.Posters);
        }
    }
}