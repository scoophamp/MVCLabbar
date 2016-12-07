using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class ImageModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "You must type in a name")]
        public string Name { get; set; }
        public IEnumerable<CommentModel> CommentModels { get; set; }

    }
}