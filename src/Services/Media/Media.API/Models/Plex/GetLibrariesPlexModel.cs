namespace Media.API.Models
{
    public class GetLibrariesPlexModel : ServerUrlPlexModel
    {
        public string[] LibraryKeys { get; set; }
        public string[] Types { get; set; }
        public string[] Titles { get; set; }
    }
}