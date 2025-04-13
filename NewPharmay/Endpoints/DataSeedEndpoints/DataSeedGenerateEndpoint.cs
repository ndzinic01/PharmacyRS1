namespace NewPharmacy.Endpoints.DataSeedEndpoints;

using Microsoft.AspNetCore.Mvc;
using NewPharmacy.Data.Models.Auth;
using NewPharmacy.Data.Models;
using NewPharmacy.Data;
using NewPharmacy.Helper.Api;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Runtime.Intrinsics.X86;

[Route("data-seed")]
public class DataSeedGenerateEndpoint(ApplicationDbContext db)
    : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<string>
{
    [HttpPost]
    public override async Task<string> HandleAsync(CancellationToken cancellationToken = default)
    {

        var existingCategories = db.Categories.ToList();
        // Kreiranje kategorija
        var requiredCategoryNames = new List<string>
        {
            "Your health",
            "Beauty and care",
            "Childcare",
            "Skin protection",
            "Devices"
        };
        foreach (var catName in requiredCategoryNames)
        {
            if (!existingCategories.Any(c => c.Name == catName))
            {
                var newCategory = new Category { Name = catName };
                db.Categories.Add(newCategory);
                existingCategories.Add(newCategory); // Add to in-memory list as well
            }
        }

     


        await db.SaveChangesAsync(cancellationToken); // Save added categories

        // Map to category objects for easy reference
        var categories = requiredCategoryNames
            .Select(name => existingCategories.First(c => c.Name == name))
            .ToList();

        // Kreiranje proizvoda
        var products = new List<Product>
        {
            new Product {
                Name = "Flobian capsules A10",
                Description = "Flobian® is a dietary supplement that helps with irritable bowel syndrome (stomach gas, flatulence, stomach pain, irregular bowel movements), and it is extremely successfully used throughout Europe and America as a natural, completely safe and thoroughly tested product.",
                Price = 18.30,
                QuantityInStock = 27,
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/flobian_kapsule_a10-400x400.jpg",
                Category = categories[0],
                IsDiscounted = true,
                DiscountPercentage = 10,
                DatumDodavanja = DateTime.Now },
            new Product {
                Name = "Clinique PopTM Lip + Cheek Oil Black Honey 7ml",
                Description = "Clinique Pop Lip + Cheek Oil in Black Honey – a multi-purpose tinted oil that delivers the fresh, dewy glow of our iconic Black Honey shade to lips and cheeks.",
                Price = 59.60,
                QuantityInStock = 10,
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/CL BLACK HONEY LIP OIL-400x400.jpg",
                Category = categories[0],
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Herbiko Propomucil syrup for children 120ml",
                Description = "Propomucil syrup for children is the only one that contains natural propolis purified by innovative technology, into which natural N-acetylcysteine (NAC) is incorporated, which breaks down the secretion and throws it out.",
                Category = categories[0], 
                Price = 10.70, 
                QuantityInStock = 30, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/2020095-228x228.jpg",
                IsDiscounted = true,
                DiscountPercentage = 12,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Vitamin C 1000g Powder 150g",
                Description = "Vitamin C is a powerful antioxidant, supporting the immune and nervous systems. It is recommended for athletes and recreationists, for everyone who wants to strengthen the immune system and for everyone who wants to raise their energy level.",
                Category = categories[0], 
                Price = 12.90, 
                QuantityInStock = 22, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Vitamin-C-1000mg-u-prahu-150g-500x500.jpg",
                IsDiscounted = true,
                DiscountPercentage = 14,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Arnika gel 250ml Cydonia",
                Description = "The ingredients act as analgesics (reduce the intensity of pain), anti-inflammatory, immunostimulating and as astringents, reducing swelling and pain in case of injuries and consequences of accidents such as, for example. hematomas, dislocations, contusions, edema due to fractures, rheumatic problems in muscles and joints.",
                Category = categories[0], 
                Price = 6.10, 
                QuantityInStock = 14, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/arnika-gel-tuba-100ml-Cydonia-228x228.jpg",
                IsDiscounted = true,
                DiscountPercentage = 40,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Advancis Throat spray 20ml",
                Description = "To relieve the symptoms of a sore and inflamed throat.",
                Category = categories[0], 
                Price = 18.80, 
                QuantityInStock = 33, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Advancis-Throat-Sprej-20-ml-apoteka-monis.png-500x500.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Melem original 10ml",
                Description = "Melem is an original cream that loves healthy skin and, with daily use, allows your skin to be hydrated, nourished and resistant to external influences.",
                Category = categories[0], 
                Price = 6.20, 
                QuantityInStock = 20, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/2040096-400x400.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "A-DERMA Shower gel 500ml",
                Description = "It cleans, hydrates and protects the fragile skin of children (older than 2 years) and adults. It contains a gentle cleansing base and balancing ingredients.",
                Category = categories[1], 
                Price = 34.80, 
                QuantityInStock = 20, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/A-Derma-gel-za-tusiranje-500-ml-Super-Apoteka-228x228.png",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now
            },
            new Product { 
                Name = "Gloria scalp peeling 100ml ",
                Description = "Scalp peeling is specially designed for oily scalp and dandruff-prone hair.",
                Category = categories[1], 
                Price = 17.60, 
                QuantityInStock = 22, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Gloria-Piling-za-vlasiste-Super-Apoteka-500x500.png",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "CeraVe oil control-cream 52ml + floaming gel 236ml ",
                Description = "For combination to oily skin• Helps balance oily skin",
                Category = categories[1], 
                Price = 43.00, 
                QuantityInStock = 14, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/CERAVE SET-500x500.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "BIOMD First Aid Face Cream 40ml",
                Description = "First Aid Face Cream is an organic, natural and hypoallergenic face cream that is great for sensitive skin with a burning and hot sensation.",
                Category = categories[1], 
                Price = 34.90, 
                QuantityInStock = 30, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/BIOMD-First-aid-krema-za-lice-40ml-500x500.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Neven Gel 100ml Cydonia",
                Description = "Marigold flower tincture (Calendula officinalis), as well as rose geranium oil (Pelargonium roseum), have an analgesic effect (reduce the intensity of pain)",
                Category = categories[1], 
                Price = 3.00, 
                QuantityInStock = 19, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/neven-gel-tuba-100ml-Cydonia-228x228.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "VICHY Capital Soleil Baby Milk SPF50+ 300ml",
                Description = "High protection for children in a large package\r\nFor fair-skinned children.To combat the harmful effects of UV rays",
                Category = categories[1], 
                Price = 47.10, 
                QuantityInStock = 20, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/3337871323639_1-500x500.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "ECODENTA Children's toothbrush Soft A1 ",
                Description = "Toothbrush designed for daily care of milk and permanent teeth of children from 1 to 7 years of age.",
                Category = categories[2], 
                Price = 09.10, 
                QuantityInStock = 19, Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Ecodenta-Djecija-cetkica-soft-A1-228x228.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { Name = "A-DERMA Exomega Control Emollient Balm 200ml",
                Description = "EXOMEGA CONTROL is a complete line of products for hygiene and care of dry skin prone to atopy.",
                Category = categories[2], 
                Price = 32.60, 
                QuantityInStock = 20, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/A-DERMA-Exomega-Control-Emolijentni-balzam-200ml-500x500.jpg",
                IsDiscounted = false, 
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Humana 1800g",
                Description = "Humana 1 contains high-quality nutrients and energy and is adapted to the special nutritional needs of a newborn during the first 6 months of life.",
                Category = categories[2], 
                Price = 44.90, 
                QuantityInStock = 32, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/humana-228x228.png",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product {
                Name = "Apiglucan Immuno syrup",
                Description = "Apiglucan Imuno is a liquid food supplement that contains (1-3), (1-6)-beta-D-glucan, obtained by extraction from the yeast Saccharomyces cerevisiae, which has the best known effect on the activation of immunity, but is also used for a number of other conditions and ailments.",
                Price = 15.80,
                QuantityInStock = 20,
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/apiglukan superapoteka2-400x400.jpg",
                Category = categories[2],
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "PINO 3D Puzzle Urgent",
                Description = "The Mini 3D puzzle is a didactic tool that helps children learn to recognize shapes, practice coordination of movements, and the ability to combine different elements.",
                Category = categories[2], 
                Price = 09.40, 
                QuantityInStock = 12, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/02170022-400x400.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product {
                Name = "MAM Fruit Pacifier",
                Description = "Perfect for little beginners: with MAM pacifiers for fresh fruit and soft vegetables you can taste without fear of choking",
                Category = categories[2], 
                Price = 18.90, 
                QuantityInStock = 35, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/MAM_duda_za_voce-500x500.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Trudi Shampoo 250ml",
                Description = "Trudi shampoo with flower pollen extract is specially formulated for washing delicate and sensitive children's hair, and is suitable for everyday use.",
                Category = categories[2], 
                Price = 10.10, 
                QuantityInStock = 21, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Trudi-Sampon-250-ml-Super-Apoteka-500x500.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "AVENE Sun Tinted Cream SPF50+ 50ml",
                Description = "Tinted sun protection cream SPF 50+ is intended for dry sensitive facial skin, always prone to sunburn or exposed to intense sunlight.",
                Category = categories[3], 
                Price = 44.70 , 
                QuantityInStock = 13, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/AVENE-SUN-Tonirana-krema-SPF50-50ml-500x500.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Mapez spray 100ml",
                Description = "Natural protection against mosquitoes and other insects\r\n\r\nMapez spray is a mixture of non-toxic, non-irritating, effective, natural extracts suitable for use even in the youngest children from the first days of life.",
                Category = categories[3], 
                Price = 16.20 , 
                QuantityInStock = 16, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Mapez-sprej-protiv-komaraca-za-djecu-100ml-228x228.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Hansaplast Aqua Protect Waterproof patch",
                Description = "Hansaplast Aqua Protect patches are waterproof and suitable for covering all types of minor wounds.Flexible, waterproof material protects when bathing and showering.",
                Category = categories[3], 
                Price = 7.00, 
                QuantityInStock = 15, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/hansaplast-flaster-aqua-protect-400x400.png",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Gloria Body myst 200ml",
                Description = "A soothing body mist, rich in moisturizing active substances, regenerates and refreshes the skin during hot summer days.Gives the skin a healthy look. Red algae with skin proteins create a protective layer that protects against external harmful influences, while ferulic acid has a photoprotective effect. The product is quickly absorbed and does not leave greasy traces. By pressing the pump, spray the product on the target area.",
                Category = categories[3], 
                Price = 16.50, 
                QuantityInStock = 13, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Gloria-Body-mist-200-ml-Super-Apoteka-500x500.png",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "Laboratorios BABE Aloe Vera gel 300ml",
                Description = "Aloe vera gel that moisturizes, soothes, softens, refreshes and restores the skin. It is especially recommended for sensitive and irritated skin.\r\nSometimes our skin becomes irritated due to situations such as prolonged exposure to the sun, shaving or waxing.",
                Category = categories[3], 
                Price = 33.90, 
                QuantityInStock = 10, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Aloe-Vera-300ml-500x500.png",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "URIAGE Thermal water 150ml",
                Description = "Uriage thermal water for daily skin care\r\nNaturally isotonic, 100% Uriage thermal water is very rich in minerals and trace elements.\r\n100% natural and bacteriologically clean.",
                Category = categories[3], 
                Price = 17.40, 
                QuantityInStock = 19, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/URIAGE-Termalna-voda-150ml-228x228.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "BEURER BY 84 Baby monitor",
                Description = "The analog baby monitor shows you your baby's mood using baby emotions. The device is suitable for every household thanks to its extremely long range of up to 800 m.",
                Category = categories[4], 
                Price = 135.90, 
                QuantityInStock = 9, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/beurer-baby-monitor-BY84-500x500.png",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "BEURER FC 41 Pore cleaner",
                Description = "The deep pore cleaner enables deep cleaning of the pores thanks to the most modern vacuum technology.\r\nUsing round attachments, spots, blackheads and dead skin cells are effectively removed.",
                Category = categories[4], 
                Price = 58.20, 
                QuantityInStock = 6, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/FC41-500x500.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "BEURER FC 65 Facial cleansing brush",
                Description = "The Beurer Pureo Deep clear facial brush enables gentle and thorough cleaning of the facial skin.\r\nThe brush cleans the facial skin by vibration or pulsation, but also improves circulation.",
                Category = categories[4], 
                Price = 85.50, 
                QuantityInStock = 9, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/BEURER-FC-65-cetka-za-ciscenje-lica-0-500x500.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "MEDISANA Manicure and pedicure device MP815",
                Description = "Care and treatment of nails, cuticles and small calluses.",
                Category = categories[4], 
                Price = 89.50, 
                QuantityInStock = 4, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/m815-500x500.png",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "BEURER LA 20 Aroma diffuser",
                Description = "The aroma diffuser for essential oils fills the entire room with pleasant scents using ultrasound technology.",
                Category = categories[4], 
                Price = 78.00, 
                QuantityInStock = 7, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/beurer-aroma-difuzer-LA20-500x500.png",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
             new Product {
                Name = "Elixir spray against mosquitoes and ticks 100ml",
                Description = "Protection against mosquitoes and ticks for adults and children over 2 years old.",
                Category = categories[4],
                Price = 9.10,
                QuantityInStock = 11,
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Eliksir-sprej-za-komarce-i-krpelje-100ml-400x400.png",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product { 
                Name = "BEURER MG 17 mini spa massager",
                Description = "The spa mini massager is waterproof and therefore can be used even under water, in wellness or any other occasion.",
                Category = categories[4], 
                Price = 25.50, 
                QuantityInStock = 4, 
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Beurer-MG-17-mini-spa-masazer-228x228.jpg",
                IsDiscounted = false,                
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
            new Product {
                Name = "BEURER MG 17 mini spa massager",
                Description = "The spa mini massager is waterproof and therefore can be used even under water, in wellness or any other occasion.",
                Category = categories[4],
                Price = 25.50,
                QuantityInStock = 4,
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Beurer-MG-17-mini-spa-masazer-228x228.jpg",
                IsDiscounted = false,
                DiscountPercentage = null,
                DatumDodavanja = DateTime.Now },
             new Product {
                Name = "AVENE Balzam za usne 4g",
                Description = "Product for daily care of sensitive lips.\r\nFor soft, hydrated lips, whatever the circumstances.",
                Category = categories[1],
                Price = 14.90,
                QuantityInStock = 16,
                Picture = "https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/AVENE-Balzam-za-usne-4g-400x400.jpg",
                IsDiscounted = true,
                DiscountPercentage = 10,
                DatumDodavanja = DateTime.Now }



        };
        foreach (var product in products)
        {
            if (!db.Products.Any(p => p.Name == product.Name))
                db.Products.Add(product);
        }
        

        // Kreiranje korisnika
        var users = new List<MyAppUser>
        {
            new MyAppUser
            {
                Username = "anaanic",
                Password = "ana123",
                FirstName = "Ana",
                LastName = "Anic",
                IsAdmin = true,
                IsCustomer = false,
                IsPharmacist = false
            },
            new MyAppUser
            {
                Username = "mujomujic",
                Password = "mujo123",
                FirstName = "Mujo",
                LastName = "Mujic",
                IsAdmin = false,
                IsCustomer = true,
                IsPharmacist = false
            },
            new MyAppUser
            {
                Username = "husohusic",
                Password = "huso123",
                FirstName = "Huso",
                LastName = "Husic",
                IsAdmin = false,
                IsCustomer = false,
                IsPharmacist = true
            },
            new MyAppUser
            {
                Username = "admin",
                Password = "admin123", // u produkciji koristi hash
                FirstName = "Admin",
                LastName = "Korisnik",
                IsAdmin = true,
                IsPharmacist = false,
                IsCustomer = false
            },
            new MyAppUser
            {
                Username = "farma",
                Password = "farma123",
                FirstName = "Farmaceut",
                LastName = "Korisnik",
                IsAdmin = false,
                IsPharmacist = true,
                IsCustomer = false
            },
            new MyAppUser
            {
                Username = "kupac",
                Password = "kupac123",
                FirstName = "Kupac",
                LastName = "Korisnik",
                IsAdmin = false,
                IsPharmacist = false,
                IsCustomer = true
            }
        };
        foreach (var user in users)
        {
            if (!db.MyAppUsers.Any(u => u.Username == user.Username))
                db.MyAppUsers.Add(user);
        }
        // Kreiranje dobavljača
        var suppliers = new List<Supplier>
        {
            new Supplier { Name = "Hercegovinalijek d.o.o. Mostar", Address = "Muje Pašića 4, Mostar 88000", Phone = "036 501-500",Email ="info@hercegovinalijek.ba" },
            new Supplier { Name = "Bosnalijek d.d. Sarajevo", Address = "Jukićeva 53, Sarajevo 71000", Phone = "033 254-400",Email ="info@bosnalijek.ba" },
            new Supplier { Name = "ZADA Pharmaceuticals d.o.o. Lukavac", Address = "GH7C+R2M, M4, Bistarac Donji", Phone = "035 551-140",Email ="zada@zada.ba" },
        };

        var advertisements = new List<Advertisement>
        {
            new Advertisement {Title ="Yasenka sinage beauty", imageURL="https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/superapoteka_web_novembar_Yasenka skinage beauty.jpg"},
            new Advertisement {Title = "Yasenka shake", imageURL="https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/superapoteka_web_novembar_Yasenka_shake.jpg"},
            new Advertisement{Title="Defendil", imageURL="https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/DEFENDIL 1.jpg"},
            new Advertisement{Title="Waya", imageURL="https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/WAYA 1.jpg"},
            new Advertisement{Title="Ducray set", imageURL="https://rs1pharmacyimages.blob.core.windows.net/advertisement-images/Ducray set 1.jpg"}
        };
        foreach (var ad in advertisements)
        {
            if (!db.Advertisements.Any(a => a.Title == ad.Title))
                db.Advertisements.Add(ad);
        }

        
        await db.SaveChangesAsync(cancellationToken);
        return "Seeder ran successfully: New data added if it didn't already exist.";
    }
}