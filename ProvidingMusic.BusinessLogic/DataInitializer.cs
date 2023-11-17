using Microsoft.EntityFrameworkCore.Infrastructure;
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
            var data = _dbContext.Bands.ToList();

            //var exceptSongs = json.Select(b => b.Albums.Select(a => a.ListSongs))
            //    .Except(data.Select(b => b.Albums.Select(a => a.ListSongs))).First();

            //var exceptAlbums = json.Select(b => b.Albums)
            //    .Except(data.Select(b => b.Albums));

            //var exceptGM = json.Select(b => b.GroupMembers)
            //    .Except(data.Select(b => b.GroupMembers));


            //if (json.Equals(data) is not true)
            //{
            //    if (data.Select(b => b.Name).Contains(json.Select(j => j.Name).ToString()))
            //    {
            //        _bandService.UpdateAsync(json.SingleOrDefault());
            //    }
            //    else
            //    {
            //        var nameId = data.Last(j => j.Name != json.Select(b => b.Name).ToString()).Id;
            //        _bandService.DeleteAsync(nameId);//нельзя удалить из-за зависимостей
            //    }
            //}           
            _bandService.DeleteAsync(1);//нельзя удалить из-за зависимостей

            return "";
        }
    }
}
