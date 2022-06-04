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
            IPipe pipeSerialDos = new PipeSerial(filterNegative, pipeNull);
                                      
            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerialUno = new PipeSerial(filterGreyscale, pipeSerialDos);
            
            IPicture image = pipeSerialUno.Send(picture);

            provider.SavePicture(image, @"beer2.jpg"); 

            IPipe pipeNull2 = new PipeNull();
            
            IFilter filterTwitter2 = new FilterTwitter("prueba beer 2");
            IPipe pipeSerial3_5 = new PipeSerial(filterTwitter2, pipeNull2);

            IFilter filterSave = new FilterSave();
            IPipe pipeSerial3 = new PipeSerial(filterSave, pipeSerial3_5);

            IFilter filterNegative2 = new FilterNegative();
            IPipe pipeSerial2 = new PipeSerial(filterNegative, pipeSerial3);
            
            IFilter filterTwitter = new FilterTwitter("prueba beer 1");
            IPipe pipeSerial1_5 = new PipeSerial(filterTwitter, pipeSerial2);

            IFilter filterSave2 = new FilterSave();
            IPipe pipeSerial1 = new PipeSerial(filterSave2, pipeSerial1_5);
            
            IFilter filterGreyscale2 = new FilterGreyscale();
            IPipe pipeSerial0 = new PipeSerial(filterGreyscale2, pipeSerial1);
            pipeSerial0.Send(picture);


        }
    }
}
