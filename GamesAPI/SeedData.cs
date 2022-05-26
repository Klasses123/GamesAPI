using GamesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI
{
    public class SeedData
    {
        public SeedData()
        {

        }

        public void SetSeedData(ModelBuilder modelBuilder)
        {
            var horrorId  = "8ddabede-af78-414e-a786-9368f74a7abb";
            var mmoRpgId  = "67c016fa-99cc-43af-b626-3809f38971b6";
            var shooterId = "9b75d1cb-b714-41ed-b0df-be8ffdb10e26";

            modelBuilder.Entity<Genre>(g =>
            {
                g.HasData(new[]
                {
                    new { Id = Guid.Parse(horrorId), Name = "Horror" },
                    new { Id = Guid.Parse(mmoRpgId), Name = "MMO RPG" },
                    new { Id = Guid.Parse(shooterId), Name = "Shooter" }
                });
            });

            var activisionBlizzardId = "32d88b31-afa7-42ef-9e63-352c398408ba";
            var valveId = "940467c3-32d2-4149-bd8b-d1876bae1318";
            var panicButtonGamesId = "cfac1b0d-5780-4f6e-bf8e-53d1ed19536d";

            modelBuilder.Entity<DeveloperStudio>(ds =>
            {
                ds.HasData(new[]
                {
                    new { Id = Guid.Parse(activisionBlizzardId), Name = "ActivisionBlizzard" },
                    new { Id = Guid.Parse(valveId), Name = "Valve" },
                    new { Id = Guid.Parse(panicButtonGamesId), Name = "Panic Button Games" }
                });
            });

            var wowId = "cb1f1b39-12ea-4458-9d36-51dac268fe21";
            var l4dId = "b6adad18-ffd2-4cf2-add4-b03c462c5b62";
            var hl2Id = "eee8f6ea-2096-47fb-a4a1-9de9cd41771d";
            var apexId = "d03ef913-6d54-41cc-8f59-4a5a90b4d292";

            modelBuilder.Entity<VideoGame>(vg =>
            {
                vg.HasData(new[] 
                { 
                    new 
                    { 
                        Id = Guid.Parse(wowId), 
                        DeveloperStudioId = Guid.Parse(activisionBlizzardId),
                        Name = "World of warcraft" 
                    },
                    new
                    {
                        Id = Guid.Parse(l4dId),
                        DeveloperStudioId = Guid.Parse(valveId),
                        Name = "Left 4 Dead"
                    },
                    new
                    {
                        Id = Guid.Parse(hl2Id),
                        DeveloperStudioId = Guid.Parse(valveId),
                        Name = "Half-Life 2"
                    },
                    new
                    {
                        Id = Guid.Parse(apexId),
                        DeveloperStudioId = Guid.Parse(panicButtonGamesId),
                        Name = "Apex Legends"
                    }
                });

            });

            modelBuilder.Entity<VideoGameGenre>(vgg =>
            {
                vgg.HasData(new[]
                {
                    new 
                    { 
                        Id = Guid.Parse("e4387219-6daa-4e9b-ae04-5037cd911332"), 
                        GameId = Guid.Parse(wowId), 
                        GenreId = Guid.Parse(mmoRpgId) 
                    },

                    new 
                    { 
                        Id = Guid.Parse("782412f4-53cb-402e-a830-21a5b43be849"), 
                        GameId = Guid.Parse(l4dId), 
                        GenreId = Guid.Parse(shooterId) 
                    },
                    new 
                    { 
                        Id = Guid.Parse("4d95eb9b-4fb4-4a35-96af-d71961fff409"), 
                        GameId = Guid.Parse(l4dId), 
                        GenreId = Guid.Parse(horrorId) 
                    },

                    new 
                    { 
                        Id = Guid.Parse("7b878b48-17fc-4142-b466-153005e439bf"), 
                        GameId = Guid.Parse(hl2Id), 
                        GenreId = Guid.Parse(shooterId) 
                    },
                    new 
                    { 
                        Id = Guid.Parse("3bfbd03d-bf3a-4137-863e-b89ff446d87c"), 
                        GameId = Guid.Parse(hl2Id), 
                        GenreId = Guid.Parse(horrorId) 
                    },

                    new 
                    { 
                        Id = Guid.Parse("2b5c4fb6-d563-4f31-aeac-60e8c16102ee"), 
                        GameId = Guid.Parse(apexId), 
                        GenreId = Guid.Parse(shooterId) 
                    }
                });
            });
        }
    }
}
