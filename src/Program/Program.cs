using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");          
            IPipe pipeNull = new PipeNull();
            
            IFilter filterNegative = new FilterNegative();
            IPipe pipeSerialTres = new PipeSerial(filterNegative, pipeNull);
            
             
            IFilter saveFilter = new FilterSave();
            IPipe pipeSerialDos = new PipeSerial(saveFilter, pipeSerialTres);
            

            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerialUno = new PipeSerial(filterGreyscale, pipeSerialDos);
            
            IPicture image = pipeSerialUno.Send(picture);

            provider.SavePicture(image, @"beer2.jpg");       
        }
    }
}
