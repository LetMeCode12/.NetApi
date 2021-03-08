using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Models{

    public class UserLogin{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        [JsonIgnore]
        public User User {get;set;}
    }

}