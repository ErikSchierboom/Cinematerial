namespace Cinematerial
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A Cinematerial poster.
    /// </summary>
    [DataContract]
    public class CinematerialPoster
    {
        /// <summary>
        /// Gets or sets the URL to the poster image. 
        /// </summary>
        [DataMember(Name = "image_location")]
        public string Url { get; set; }
    }
}