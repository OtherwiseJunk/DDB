using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DartsDiscordBots.Models;

public class BestOfXMessageJson
{
    [Key, ForeignKey("BestOf")]
    public int BestOfId { get; set; }
    public string MessageJson { get; set; }
    public BestOf BestOf { get; set; }
}