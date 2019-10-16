using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMaker.Util
{
    public static class CommonTool
    {
        public static void Shuffle<T>(T[] items)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < items.Length / 2; i++)
            {
                int j = random.Next(i + 1, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }
    }
}
