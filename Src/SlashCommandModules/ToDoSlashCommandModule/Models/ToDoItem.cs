using System.ComponentModel.DataAnnotations;

namespace DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        public ulong DiscordUserId { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }

        public ToDoItem() { }
        public ToDoItem(ulong discordUserId, string text)
        {
            DiscordUserId = discordUserId;
            Text = text;
            IsCompleted = false;
        }
    }
}
