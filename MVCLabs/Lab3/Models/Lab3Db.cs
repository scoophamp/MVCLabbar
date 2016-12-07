using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Lab3Db : DbContext
    {
        public DbSet<ImageModel> ImageModels { get; set; }
        public DbSet<CommentModel> CommentModels { get; set; }
        public DbSet<AlbumModel> AlbumModels { get; set; }
    }
}