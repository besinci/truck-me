namespace TruckMe.Crawler
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using TruckMe.Core;
    using TruckMe.Data;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Take motorcycle brands and models from yellow site.");

            SynchBrands synchBrands = new SynchBrands();

            var brands = new List<Brand>();

            using (var context = new TruckMeContext())
            {
                /*
                    SELECT DISTINCT BRAND.Href FROM dbo.Brands AS BRAND
                    LEFT JOIN dbo.Models AS MODEL ON BRAND.Id = MODEL.BrandId
                    WHERE MODEL.Id IS NULL
                 */

                brands = context.Brands
                            .Include(x => x.Models)
                            .Where(x => !x.Models.Any())
                            .Select(x => x)
                            .ToList();
            }

            foreach (var brand in brands)
            {
                var models = synchBrands.TakeModels(brand.Href, brand.Id).Result;

                using (var context = new TruckMeContext())
                {
                    context.Models.AddRange(models);
                    context.SaveChanges();
                }
                Thread.Sleep(5000);
            }

            Console.ReadLine();
        }
    }
}
