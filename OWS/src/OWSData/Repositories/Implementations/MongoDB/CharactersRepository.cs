﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using OWSData.Models.StoredProcs;
using OWSData.Repositories.Implementations.MongoDB.Models;
using OWSShared.Options;

namespace OWSData.Repositories.Implementations.MongoDB
{
    class CharactersRepository
    {
        private readonly IOptions<StorageOptions> storageOptions;
        private readonly IMongoCollection<CharacterStats> characterStats;

        public CharactersRepository(IConfiguration config)
        {
//#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
//            MongoDefaults.GuidRepresentation = GuidRepresentation.Standard;
//#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            var client = new MongoClient(config.GetConnectionString("WorldBuilderDb"));
            var database = client.GetDatabase("OWSCharacterData");
            characterStats = database.GetCollection<CharacterStats>("CharacterStats");
        }

        public CharactersRepository(IOptions<StorageOptions> storageOptions)
        {
            //var connection = @"Server=desktop-rvdfpao\sqlexpress;Database=d20;Trusted_Connection=True;ConnectRetryCount=0";
            //this.ConnectionString = connection;
            this.storageOptions = storageOptions;
        }

        public async Task<GetCharByCharName> GetCharByCharName(Guid _CustomerGUID, string _CharacterName)
        {
            GetCharByCharName OutputCharacter = new GetCharByCharName();

            return await Task.FromResult(OutputCharacter);
        }

        public async Task<JoinMapByCharName> JoinMapByCharName(Guid _CustomerGUID, string _CharacterName, string _ZoneName, int _PlayerGroupType)
        {
            JoinMapByCharName OutputObject = new JoinMapByCharName();

            return await Task.FromResult(OutputObject);
        }

        public async Task<CharacterStats> GetCharacterStats(Guid _CustomerGUID, string _CharacterName)
        {
            CharacterStats outputCharacterStats = new CharacterStats();

            return await characterStats.Find<CharacterStats>(character => character.CustomerId == _CustomerGUID && character.CharacterName == _CharacterName).FirstOrDefaultAsync();
        }

        public async Task AddCharacterStats(Guid _CustomerGUID, string _CharacterName, string _CharacterStatsJSONString)
        {
            CharacterStats inputCharacterStats = new CharacterStats();

            inputCharacterStats.CustomerId = _CustomerGUID;
            inputCharacterStats.CharacterName = _CharacterName;
            inputCharacterStats.CharacterStatsJSONString = _CharacterStatsJSONString;

            await characterStats.InsertOneAsync(inputCharacterStats);
        }

        //Returns true if there was a record found to update, otherwise returns false
        public async Task<bool> UpdateCharacterStats(Guid _CustomerGUID, string _CharacterName, string _CharacterStatsJSONString)
        {
            CharacterStats foundCharacterStats = new CharacterStats();

            foundCharacterStats = await GetCharacterStats(_CustomerGUID, _CharacterName);

            if (foundCharacterStats == null)
            {
                return false;
            }

            foundCharacterStats.CharacterStatsJSONString = _CharacterStatsJSONString;

            await characterStats.ReplaceOneAsync(foundCharacterStats.Id, foundCharacterStats);

            return true;
        }

        //Returns true if there was a record found to update, otherwise returns false if we had to add a new row
        public async Task<bool> AddOrUpdateCharacterStats(Guid _CustomerGUID, string _CharacterName, string _CharacterStatsJSONString)
        {
            CharacterStats foundCharacterStats = new CharacterStats();

            foundCharacterStats = await GetCharacterStats(_CustomerGUID, _CharacterName);

            if (foundCharacterStats == null)
            {
                await AddCharacterStats(_CustomerGUID, _CharacterName, _CharacterStatsJSONString);

                return false;
            }

            foundCharacterStats.CharacterStatsJSONString = _CharacterStatsJSONString;

            await characterStats.ReplaceOneAsync(foundCharacterStats.Id, foundCharacterStats);

            return true;
        }

        //Returns true if there was a record found to remove, otherwise returns false
        public async Task<bool> RemoveCharacterStats(Guid _CustomerGUID, string _CharacterName)
        {
            CharacterStats foundCharacterStats = new CharacterStats();

            foundCharacterStats = await GetCharacterStats(_CustomerGUID, _CharacterName);

            if (foundCharacterStats == null)
            {
                return false;
            }

            await characterStats.DeleteOneAsync(foundCharacterStats.Id);

            return true;
        }
    }
}
