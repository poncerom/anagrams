using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramRepository
{
    public interface IAnagramRepository
    {
        List<String> ReadData();
    }
}
