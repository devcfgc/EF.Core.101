using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string ProductCommentsURL { get; set; }
        public Product Product { get; set; }
    }
}
