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
            
            IFilter twitterFilter2 = new FilterTwitter("prueba beer", @"intermediateFilter0.jpg");
            IPipe pipeSerialDosPuntoCinco = new PipeSerial(twitterFilter2, pipeSerialTres);
             
            IFilter saveFilter = new FilterSave();
            IPipe pipeSerialDos = new PipeSerial(saveFilter, pipeSerialDosPuntoCinco);
                    
            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerialUno = new PipeSerial(filterGreyscale, pipeSerialDos);
            
            IFilter twitterFilter1 = new FilterTwitter("prueba beer", @"beer.jpg");
            IPipe pipeSerialCeroPuntoCinco = new PipeSerial(twitterFilter1, pipeSerialUno);

            IPicture image = pipeSerialCeroPuntoCinco.Send(picture);

            IFilter twitterFilter3 = new FilterTwitter("prueba beer", @"beer2.jpg");

            provider.SavePicture(image, @"beer2.jpg"); 
            
        }
    }
}
