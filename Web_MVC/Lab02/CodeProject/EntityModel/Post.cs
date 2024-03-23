namespace EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostId { get; set; }

        [Column(TypeName = "text")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public int? BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
