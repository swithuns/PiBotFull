using System;
using System.Collections.Generic;
using System.Text;

namespace AudioReader
{

    class Sequence
    {
        public List<Alternatives> Alternatives { get; set; }
    }
    class Alternatives
    {
        public string Transcript { get; set; }
        public Double Confidence { get; set; }
    }
}
