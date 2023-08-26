﻿using DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule.Interfaces;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsDiscordBots.SlashCommandModules.ToDoSlashCommandModule
{
    public class ToDoSlashCommandModule : BaseSlashCommandModule, ISlashCommandModule
    {
        private IToDoService _service { get; set; }
        private const string ToDoList = "todo";
        private const string ToDoAdd = "todoadd";
        private const string ToDoComplete = "todocomplete";
        private const string ToDoClear = "todoclear";
        private SlashCommandProperties ToDoListCommandProperties = new SlashCommandBuilder()
                                                                    .WithName(ToDoList)
                                                                    .WithDescription("List your TODO items")
                                                                    .WithDefaultPermission(true).Build();
        private SlashCommandProperties ToDoAddCommandProperties = new SlashCommandBuilder()
                                                            .WithName(ToDoAdd)
                                                            .WithDescription("Add an item to your TODO list. No more than 50 characters.")
                                                            .AddOption("text", ApplicationCommandOptionType.String, "The text to add to your TODO list", true, maxLength: 150, minLength: 3)
                                                            .WithDefaultPermission(true).Build();
        private SlashCommandProperties ToDoCompleteCommandProperties = new SlashCommandBuilder()
                                                            .WithName(ToDoComplete)
                                                            .WithDescription("Mark the specified TODO item as complete, by ID. For multiple provide a comma separated list.")
                                                            .AddOption("identifier", ApplicationCommandOptionType.String, "The ID of the TODO item to mark as completed. For multiple, use a comma between IDs (no spaces)", true, maxLength: 150, minLength: 1)
                                                            .WithDefaultPermission(true).Build();
        private SlashCommandProperties ToDoClearCommandProperties = new SlashCommandBuilder()
                                                            .WithName(ToDoClear)
                                                            .WithDescription("Remove all TODO items marked as complete.")
                                                            .WithDefaultPermission(true).Build();

        public ToDoSlashCommandModule(IToDoService service) : base(new() { ToDoList, ToDoComplete, ToDoClear, ToDoAdd }, "TODO")
        {
            _service = service;
        }
        public async Task HandleSocketSlashCommand(SocketSlashCommand command)
        {
            if (!IsSlashCommandManager(command.CommandName))
            {
                return;
            }
            switch (command.CommandName)
            {
                case ToDoList:
                    HandleListCommand(command);
                    break;
                case ToDoComplete:
                    HandleCompleteCommand(command);
                    break;
                case ToDoClear:
                    HandleClearCommand(command);
                    break;
                case ToDoAdd:
                    HandleAddCommand(command);
                    break;

            }
        }

        public async Task InstallModuleSlashCommands(IGuild guild, DiscordSocketClient client)
        {
            Console.WriteLine("Attempting to install TODO Module Slash Commands...");
            if (guild == null && client == null)
            {
                throw new ArgumentNullException("Either the guild or the provided discord client must not be null.", null as Exception);
            }
            try
            {
                if (guild == null)
                {
                    List<SocketApplicationCommand> commands = client.GetGlobalApplicationCommandsAsync().Result.ToList();
                    await DeletePreviousCommandVersions(commands.Where(command => IsSlashCommandManager(command.Name)).Select(command => command as IApplicationCommand).ToList());
                    Console.WriteLine("No Guild Provided, installing as Global commands.");
                    var listCommand = await client.CreateGlobalApplicationCommandAsync(ToDoListCommandProperties);
                    var addCommand = await client.CreateGlobalApplicationCommandAsync(ToDoAddCommandProperties);
                    var completeCommand = await client.CreateGlobalApplicationCommandAsync(ToDoCompleteCommandProperties);
                    var clearCommand = await client.CreateGlobalApplicationCommandAsync(ToDoClearCommandProperties);
                }
                else
                {
                    List<IApplicationCommand> commands = guild.GetApplicationCommandsAsync().Result.ToList();
                    await DeletePreviousCommandVersions(commands.Where(command => IsSlashCommandManager(command.Name)).ToList());
                    Console.WriteLine("Guild Provided, installing as Guild commands.");
                    await guild.CreateApplicationCommandAsync(ToDoListCommandProperties);
                    await guild.CreateApplicationCommandAsync(ToDoAddCommandProperties);
                    await guild.CreateApplicationCommandAsync(ToDoCompleteCommandProperties);
                    await guild.CreateApplicationCommandAsync(ToDoClearCommandProperties);
                }
                Console.WriteLine("TODO Module Installation Success!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Encountered an error installing TODO slash commands.");
                Console.WriteLine(e.Message);
            }

        }

        private void HandleListCommand(SocketSlashCommand command)
        {
            _ = command.RespondAsync(_service.BuildToDoListResponse(command.User));
        }
        private void HandleCompleteCommand(SocketSlashCommand command)
        {
            string toDoIdString = "";
            List<int> toDoIds = new();
            try
            {
                toDoIdString = (string)command.Data.Options.First().Value;
                toDoIds = toDoIdString.Split(',').Select(id => int.Parse(id)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            StringBuilder builder = new StringBuilder();
            foreach (int toDoID in toDoIds)
            {
                bool isCompleted = _service.IsToDoItemCompleted(toDoID);
                bool belongsToUser = _service.ToDoBelongsToUser(command.User.Id, toDoID);
                if (belongsToUser && !isCompleted)
                {
                    _service.MarkToDoComplete(toDoID);
                    builder.AppendLine($"Ok, I've marked item {toDoID} as complete");
                }
                else if (isCompleted && belongsToUser)
                {
                    builder.AppendLine($"Sorry, item {toDoID} has already been marked as completed.");
                }
                else
                {
                    builder.AppendLine($"Sorry, either TODO Item {toDoID} doesn't exist, or it belongs to another user");
                }
            }
            builder.Append($"{Environment.NewLine}{_service.BuildToDoListResponse(command.User)}");
            _ = command.RespondAsync(builder.ToString(), ephemeral: true);
        }
        private void HandleClearCommand(SocketSlashCommand command)
        {
            _service.ClearAllCompletedToDo(command.User.Id);
            bool toDoListNotEmpty = _service.GetUsersToDos(command.User.Id).Count > 0;
            string messageConfirmation = "Ok, I've deleted all of your completed TODO items.";
            string toDoListNotEmptyResponse = $"{Environment.NewLine}{Environment.NewLine}{_service.BuildToDoListResponse(command.User)}";

            _ = command.RespondAsync(toDoListNotEmpty ? $"{messageConfirmation}{toDoListNotEmptyResponse}" : messageConfirmation, ephemeral: true);
        }
        private void HandleAddCommand(SocketSlashCommand command)
        {
            string toDoText = (string)command.Data.Options.First().Value;
            _service.AddToDo(command.User.Id, toDoText);
            _ = command.RespondAsync($"Ok, I've added that TODO item for you.{Environment.NewLine}{Environment.NewLine}{_service.BuildToDoListResponse(command.User)}", ephemeral: true);
        }
    }
}
