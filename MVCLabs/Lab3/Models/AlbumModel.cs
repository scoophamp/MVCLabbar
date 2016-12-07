using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class AlbumModel
    {
        public int ID { get; set; }
        public IEnumerable<ImageModel> ImageModels { get; set; }

        public IEnumerable<CommentModel> CommentModels { get; set; }
    }
}