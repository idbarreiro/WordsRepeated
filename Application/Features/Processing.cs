using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class Processing : IProcessing
    {
        
        public Processing()
        {
        }

        public List<Word> FindWordsRepeated(string text)
        {
            List<Word> result = new List<Word>();

            try
            {
                text = RemoveCharacters(text);
                string[] textSeparate = text.Split(new char[] { ' ' });
                foreach (var word in textSeparate)
                {
                    int wordR = (from wordF in result
                                 where wordF.Name.Equals(word, StringComparison.OrdinalIgnoreCase)
                                 select wordF).ToList().Count;

                    if (wordR == 0)
                    {
                        int countWord = (from wordRep in textSeparate
                                         where (wordRep.Equals(word, StringComparison.OrdinalIgnoreCase))
                                         select wordRep).ToList().Count;

                        if (countWord > 1 && word != "")
                        {
                            var finalResult = new Word
                            {
                                Name = word.ToLower(),
                                Amount = countWord
                            };
                            result.Add(finalResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en la búsqueda de palabras repetidas: ", ex);
            }

            return result;
        }

        public string RemoveCharacters(string text)
        {
            string textResult = text;
            try
            {
                textResult = string.Join("", textResult.Split(',', '.'));
            }
            catch (Exception ex)
            {

                return "Ocurrió un error en la eliminación de caracteres: " + ex.Message;
            }
            
            return textResult;
        }

    }
}
