namespace TruckMe.Crawler
{
    using HtmlAgilityPack;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TruckMe.Core;

    public class SynchBrands
    {
        static string url = "https://www.sahibinden.com/kategori/motosiklet";

        public async Task<List<Brand>> TakeBrands()
        {
            var pageContent = await GetPageContent();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageContent);

            var ulTag = htmlDocument.DocumentNode
                            .Descendants("ul")
                            .Where(node => node.GetAttributeValue("class", "")
                                               .Equals("categoryList"))
                            .Select(node => node.ChildNodes)
                            .ToList();

            var brands = ulTag.FirstOrDefault().Where(x => x.Name == "li").ToList();

            var result = new List<Brand>();
            foreach (var brand in brands)
            {
                var aTag = brand.Descendants("a").FirstOrDefault();

                var brandName = aTag.GetAttributeValue("title", "-");
                var brandId = int.Parse(aTag.GetAttributeValue("data-categoryId", "-"));
                var brandHref = aTag.GetAttributeValue("href", "");

                result.Add(
                    new Brand { 
                        Name = brandName, 
                        CategoryId = brandId, 
                        Href = brandHref });
            }

            return result;
        }

        private async Task<string> GetPageContent()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Brand Crawler");

            return await client.GetStringAsync(url);
        }
    }
}
