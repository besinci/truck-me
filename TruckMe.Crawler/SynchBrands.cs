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
        private static string url = "https://www.sahibinden.com/kategori/motosiklet";

        public async Task<List<Brand>> TakeBrands()
        {
            var pageContent = await GetPageContent(url);

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

        public async Task<List<Model>> TakeModels(string model, int brandId)
        {
            var result = new List<Model>();
            var url = $"https://www.sahibinden.com/{ model }";
            var content = await GetPageContent(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);

            var brandDiv = htmlDoc.GetElementbyId("searchCategoryContainer");

            var ul = brandDiv.Descendants("ul").FirstOrDefault();
            if (ul != null)
            {
                var lis = ul.Descendants("li").ToList();

                foreach (var li in lis)
                {
                    var a = li.Descendants("a").FirstOrDefault();

                    result.Add(
                        new Model { 
                            Name = a.GetAttributeValue("title", "-"),
                            BrandId = brandId,
                        });
                }
            }

            return result;
        }

        private async Task<string> GetPageContent(string url)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "asdsadsa");

            return await client.GetStringAsync(url);
        }
    }
}
