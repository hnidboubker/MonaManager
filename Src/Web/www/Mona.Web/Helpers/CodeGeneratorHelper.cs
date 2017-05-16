using System;
using System.Collections.Generic;
using System.Linq;
using Mona.Web.Data;
using Mona.Web.Entities;

namespace Mona.Web.Helpers
{
    public class CodeGeneratorHelper
    {
        private static readonly Random random = new Random();

        public static int GenerateCode()
        {
            int result = GenerateCodeRandom();
            return result;
        }

        private static int GenerateCodeRandom()
        {
            var db = new DefaultContext();
            List<int> vals = GenerateRandom(1000, 0, Int32.MaxValue);
            IQueryable<Contact> entityCount = from t in db.Contacts select t;
            int arrange = entityCount.Count() + 1;

            int result = vals.Count() + arrange;

            return result;
        }

        // Code origine https://codereview.stackexchange.com/questions/61338/generate-random-numbers-without-repetitions

        private static List<int> GenerateRandom(int count, int min, int max)
        {
            // generate count random values.
            if (max <= min || count < 0 ||
                // max - min > 0 required to avoid overflow
                (count > max - min && max - min > 0))
            {
                // need to use 64-bit to support big ranges (negative min, positive max)
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                                                      " (" + (max - (Int64) min) + " values), or count " + count +
                                                      " is illegal");
            }

            // generate count random values.
            var candidates = new HashSet<int>();

            // start count values before max, and end at max
            for (int top = max - count; top < max; top++)
            {
                // May strike a duplicate.
                // Need to add +1 to make inclusive generator
                // +1 is safe even for MaxVal max value because top < max
                if (!candidates.Add(random.Next(min, top + 1)))
                {
                    // collision, add inclusive max.
                    // which could not possibly have been added before.
                    candidates.Add(top);
                }
            }

            // load them in to a list, to sort
            List<int> result = candidates.ToList();

            // shuffle the results because HashSet has messed
            // with the order, and the algorithm does not produce
            // random-ordered results (e.g. max-1 will never be the first value)
            for (int i = result.Count - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }
    }
}