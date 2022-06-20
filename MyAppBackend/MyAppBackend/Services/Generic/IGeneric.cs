using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.Generic
{
    public interface IGeneric
    {
        public void Upvote();
        public void Downvote();
    }
}
