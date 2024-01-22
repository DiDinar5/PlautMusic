using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic
{
    public class DataInitializer
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IBandService _bandService;
        private readonly IGroupMemberService _groupMemberService;
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;  

        public DataInitializer(ApplicationDBContext dBContext,
            IBandService bandService,
            IGroupMemberService groupMemberService,
            IAlbumService albumService,
            ISongService songService)
        {
           _dbContext = dBContext;
            _bandService = bandService;
            _groupMemberService = groupMemberService;
            _albumService = albumService;

        }

        public object SetData()
        {
            string pathToDefaultDb = "Configurations/dbconfig.json";

            var json = JsonConvert.DeserializeObject<List<Band>>(File.ReadAllText(pathToDefaultDb));
            var data = _dbContext.Bands.
                Include(b=>b.GroupMembers)
                .Include(b=>b.Albums)
                .ThenInclude(a=>a.ListSongs)
                .ToList();

            foreach (var dataBand in data)
            {
                if(!json.Any(j=>j.Name == dataBand.Name))
                {
                    _dbContext.Bands.Remove(dataBand);
                    //bandsDelete.Add(dataBand);
                }
            }
            foreach (var jsonBand in json)
            {
                if(data.Any(d=>d.Name == jsonBand.Name))
                {
                    _dbContext.Bands.Update(jsonBand);
                    //bandsUpdate.Add(jsonBand);
                }

                if(!data.Any(d => d.Name == jsonBand.Name))
                {
                    _dbContext.Bands.Add(jsonBand);
                    //bandsCreate.Add(jsonBand);
                }
            }

            _dbContext.SaveChanges();
            return "";
        }
    }
}



