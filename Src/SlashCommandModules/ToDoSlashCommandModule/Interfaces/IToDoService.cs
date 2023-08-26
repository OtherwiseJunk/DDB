using DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule.Context;
using DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule.Models;
using Discord;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule.Interfaces
{
    public interface IToDoService
    {
        public IDbContextFactory<ToDoContext> dataContextFactory { get; set; }

        public bool ToDoBelongsToUser(ulong userId, int toDoId);
        public bool IsToDoItemCompleted(int toDoId);
        public void MarkToDoComplete(int toDoId);
        public void ClearAllCompletedToDo(ulong userId);
        public void AddToDo(ulong userId, string text);
        public List<ToDoItem> GetUsersToDos(ulong userId);
        public string BuildToDoListResponse(IUser user);
    }
}
