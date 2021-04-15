using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services
{
    public class TvShowServices
    {
        private readonly Guid _userId;
        public TvShowServices (Guid userId)
        {
            _userId = userId;
        }

    }
}
