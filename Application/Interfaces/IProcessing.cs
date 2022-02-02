using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IProcessing
    {
        public List<Word> FindWordsRepeated(string text);
    }
}
