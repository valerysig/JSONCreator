using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONCreator.AuxiliaryClasses
{
    class JsonClass
    {
        #region Properties
        public List<Word> Words { get; set; }
        public List<int> WordsIncluded { get; set; }
        public SentenceClass Sentences { get; set; }
        #endregion

        #region Auxilary classes
        public class SentenceClass
        {
            public List<SentenceIndex> Sentence { get; set; }
            public String Translation { get; set; }
        }

        public struct SentenceIndex
        {
            public int Index { get; set; }
            public char Separator { get; set; }
        }
        #endregion
    }
}
