﻿using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly ISongService _songBLL;
        public SongController(ISongService songBLL)
        {
            _songBLL = songBLL;
        }

        ///<summary>
        ///Метод, который ничего не принимает и возвращает все песни
        ///</summary>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetSongs()
        {
            return Ok(await _songBLL.GetAllConnectionAsync());
        }

        ///<summary>
        ///Метод, который ничего не принимает и возвращает рандомную песню
        ///</summary>
        [HttpGet("getsongRandom")]
        public async Task<IActionResult> GetSongRandom()
        {
            return Ok(await _songBLL.GetRandomEntityConnection());
        }

        /// <summary>
        /// Метод принимает на вход наименование песни, и возвращает песню или похожее наименование в случае ошибки ввода
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Возвращает код(200,400,500) и выбранную песню</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            //if(string.IsNullOrEmpty(id))
            //    return BadRequest(new {Message = "name of song is null"});
            //EFfunctionsLike
            return Ok(await _songBLL.GetByIdConnectionAsync(id));
        }
        [HttpPost("createSong")]
        public async Task<IActionResult> CreateSong(Song song)
        {
            _songBLL.CreateConnectionAsync(song);
            return Ok(new {Message="song created"});
        }
    }
}
