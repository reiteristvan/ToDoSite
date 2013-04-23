using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoSite.Models
{
    [Table("Task")]
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty ( "id" )]
        public int Id { get; set; }

        [Required]
        [JsonProperty ( "description" )]
        public string Description { get; set; }

        [JsonProperty ( "date" )]
        [JsonConverter(typeof(JsDateConverter))]
        public DateTime Date { get; set; }

        [JsonProperty ( "isCompleted" )]
        public bool IsCompleted { get; set; }

        [JsonProperty ( "userName" )]
        public string UserName { get; set; }
    }
}