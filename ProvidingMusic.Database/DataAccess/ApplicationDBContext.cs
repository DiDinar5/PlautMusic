﻿using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.Context
{
    public class ApplicationDBContext: DbContext
    {
        //public ApplicationDBContext()
        //{
               
        //}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
                //Database.Migrations??
        }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupMusic> MusicGroups { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}