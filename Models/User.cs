using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models{

    public class User{
        [Key]
        [ForeignKey("Login")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set;}
        public string Name {get; set;}
        public string SurrName {get; set;}
        
        // [JsonIgnore]
        public UserLogin Login {get; set;}

    }

}