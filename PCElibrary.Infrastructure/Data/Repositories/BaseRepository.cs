using PCElibrary.Infrastructure.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCElibrary.Infrastructure.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly LibraryContext libraryContext;

        public BaseRepository(LibraryContext context)
        {
            libraryContext = context;
        }
    }
}
