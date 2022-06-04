using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        private string post;

        private string path;

        public FilterTwitter(string post, string path)
        {
            this.post = post;
            this.path = path;
        }

        public IPicture Filter(IPicture image)
        {
            TwitterImage twitterImage = new TwitterImage();

            twitterImage.PublishToTwitter(this.post, this.path);

            return image;
        }
    }
}