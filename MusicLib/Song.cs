using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLib
{
    public class Song
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Words { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; }
        public int Rating { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
