using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Q.A.__social_network.DTO
{   
    [Keyless]
    public class CreateQuestionDTO
    {
        public int IdQuestion { get; set; }

        public string? Question { get; set; } 
        
        public int IdUser { get; set; }
    }
}