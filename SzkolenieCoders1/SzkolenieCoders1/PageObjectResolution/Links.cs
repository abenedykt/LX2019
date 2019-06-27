using System;

namespace SzkolenieCoders1.PageObjectResolution
{
    public class Links
    {
        public Links(Uri url)
        {
            Url = url;
        }

        public Uri Url { get; }
    }
}