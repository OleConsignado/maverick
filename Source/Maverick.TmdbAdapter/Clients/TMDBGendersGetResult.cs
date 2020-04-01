using System;
using System.Collections.Generic;
using System.Text;

namespace Maverick.TmdbAdapter.Clients
{
    internal class TMDBGendersGetResult
    {
        public List<TMDBGender> Genres { get; set; }

        internal class TMDBGender
        {
            public long ID { get; set; }
            public string Name { get; set; }
        }
    }
}
