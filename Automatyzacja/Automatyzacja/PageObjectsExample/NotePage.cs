using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatyzacja.PageObjectsExample
{
    public class NotePage
    {
        private object newNoteUrl;

        public NotePage(object newNoteUrl)
        {
            this.newNoteUrl = newNoteUrl;
        }
    }
}