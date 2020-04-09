using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Contracts.Response
{
    public class ResponseData<T>
    {
        public int status { get; set; }
        public DateTime localTime { get; set; }
        public T data { get; set; }

    }
}
