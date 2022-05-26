using GamesAPI.Interfaces;

namespace GamesAPI.Models
{
    public class DeveloperStudio : IDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
