using System;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        private static int cont = 0;

        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();

            provider.SavePicture(image, @"intermediateFilter"+cont+".jpg");
            
            cont++;
            
            return image;
        }
    }
}