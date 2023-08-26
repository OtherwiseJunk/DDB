using DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule.Context
{
    public class ToDoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DATABASE"));
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
