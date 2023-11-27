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

            //List<Band> bandsCreate = new();
            //List<Band> bandsDelete = new();
            //List<Band> bandsUpdate = new();
            //var newData = new List<Band>();

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
            /*List<string> intersectNames = json.Select(b => b.Name).Intersect(data.Select(b => b.Name)).ToList();

            foreach (var nameBand in intersectNames) 
            {
                foreach (var nameData in data.Select(b => b.Name))
                {
                    if (nameData != nameBand)
                    {
                        //var idName = data.FirstOrDefault(n => n.Name == dataName).Id;
                        //bandsDelete.Add(data.Find(b=>b.Id==idName));
                        //_bandService.DeleteAsync(idName);
                    }
                }
            }*/


















            //foreach (var dataName in data.Select(b => b.Name))
            //{
            //    if (!json.Select(b => b.Name).Any(n => n == dataName))
            //    {
            //        _
            //    }
            //    if(intersectNames.Any(n=>n==dataName))
            //    {
            //        var idName = data.FirstOrDefault(n=>n.Name==dataName).Id;
            //        bandsDelete.Add(data.Find(b=>b.Id==idName));
            //    }
            //}








            //    if(data.Select(b => b.Name).Contains(json.Select(b => b.Name)))//except intersect
            //{
            //    foreach (var members in data.Select(b => b.GroupMembers))
            //        {
            //            if (members.Select(gr => gr.FirstName) == json.Select(b => b.GroupMembers.Select(gr => gr.FirstName)))
            //            {
            //                _groupMemberService.UpdateAsync(json.SelectMany(b => b.GroupMembers).FirstOrDefault());
            //            }
            //            else if (data.Select(b => b.GroupMembers).Contains(member.FirstName))){

            //            }
            //            else
            //            {
            //                _groupMemberService.CreateAsync(json.SelectMany(b => b.GroupMembers).FirstOrDefault());
            //            }

            //        }
            //        foreach (var album in data.Select(b => b.Albums))
            //        {
            //            if (album.Select(a => a.Name) == json.Select(b => b.Albums.Select(a => a.Name.ToString())))
            //            {
            //                _albumService.UpdateAsync(json.SelectMany(b => b.Albums).FirstOrDefault());
            //            }
            //            else
            //            {
            //                _albumService.CreateAsync(json.SelectMany(b => b.Albums).FirstOrDefault());
            //            }
            //        }
            //        // _bandService.UpdateAsync(json.FirstOrDefault());
            //    }
            //    else if (json.Select(b => b.Name).Contains(data.Select(b => b.Name).ToString()))
            //    {
            //        var nameId = data.Last(j => j.Name != json.Select(b => b.Name).ToString()).Id;
            //        _bandService.DeleteAsync(nameId);
            //    }
            //    else
            //    {
            //        _bandService.CreateAsync(json.FirstOrDefault());
            //    }

            //return "";
        }
    }
}



