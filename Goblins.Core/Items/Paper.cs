using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goblins.Core.Items
{
    public class Paper : Item
    {
        public IList<string> Contents { get; set; } = new List<string>();
        internal void Write(string text)
        {
            Contents.Add(text);
        }
    }
}
