namespace TruckMe.Crawler
{
    using System;

    class Program
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("Take motorcycle brands and models from yellow site.");

            SynchBrands synchBrands = new SynchBrands();
            var brands = await synchBrands.TakeBrands();

            Console.ReadLine();
        }
    }
}
