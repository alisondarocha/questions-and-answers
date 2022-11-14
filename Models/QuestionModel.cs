using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Q.A.__social_network.DTO;

namespace Q.A.__social_network.Models
{
    public class QuestionModel
    {
        [Key]
        public int IdQuestion { get; set; }

        public string? Question { get; set; }

        public int IdUser { get; set; }

        [ForeignKey("IdUser")]
        public virtual UserModel User { get; set; }
    }
}