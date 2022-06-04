using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        private string post;
        
        private static int cont = 0;

        public FilterTwitter(string post)
        {
            this.post = post;
        }

        public IPicture Filter(IPicture image)
        {
            TwitterImage twitterImage = new TwitterImage();

            twitterImage.PublishToTwitter(this.post, @"intermediateFilter"+cont+".jpg");

            cont++;

            return image;
        }
    }
}