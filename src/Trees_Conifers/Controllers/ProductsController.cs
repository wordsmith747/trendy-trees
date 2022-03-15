using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TrendyTrees.Models;

namespace TrendyTrees.Controllers
{
    public class ProductsController : Controller
    {
        public List<ProductViewModel> AllProducts { get; set; }

        public void EnsureProductsLoaded()
        {
            var products = new List<ProductViewModel>();

            {
                var plant = new ProductViewModel();
                plant.Name = "Korean fir";
                plant.Id = 1;
                plant.Description = "It is a small to medium-sized evergreen coniferous tree growing to 10–18 m (33–59 ft) tall with a trunk diameter of up to 0.7 m (2 ft 4 in), smaller and sometimes shrubby at the tree line. The bark is smooth with resin blisters and grey-brown in colour. The leaves are needle-like, flattened, 1–2 centimetres (0.4–0.8 in) long and 2–2.5 millimetres (0.08–0.10 in) wide by 0.5 mm (0.02 in) thick, glossy dark green above, and with two broad, vividly white bands of stomata below, and slightly notched at the tip. The leaf arrangement is spiral on the shoot, but with each leaf variably twisted at the base so they lie mostly either side of and above the shoot, with fewer below the shoot. The shoots are green-grey at first, maturing pinkish-grey, with scattered fine pubescence. The cones are 4–7 cm (1.6–2.8 in) long and 1.5–2 cm (0.6–0.8 in) broad, dark purple-blue before maturity; the scale bracts are long, green or yellow, and emerge between the scales in the closed cone. The winged seeds are released when the cones disintegrate at maturity about 5–6 months after pollination.";
                plant.ImageName = "JodłaKoreanska.jpg";
                plant.Price_Small = 6.3;
                plant.Price_Large = 8.4;
                plant.Number_Items_Basket = 1;
                plant.AvailableDimensions = new List<ProductDimensionInfo>();
                plant.PublishDate = DateTime.Now - TimeSpan.FromDays(31);
                plant.UnitsInStock = 5;
                plant.FreeShipping = false;
                products.Add(plant);

                //todo add product variants
                //var small = new ProductDimensionInfo();
                // small.Name = "small";
                // small.Height = 7;
                // small.Width = 3;

                //todo var large = new ProductDimensionInfo();
                //large.Name = "Large";
                //large.Height = 10;
                //large.Width = 5;

                //todo  plant.AvailableDimensions.Add(small);
                //  plant.AvailableDimensions.Add(large);
                
            }
            {
                var plant = new ProductViewModel();
                plant.Name = "Thuja occidentalis";
                plant.Id = 2;
                plant.Description = "Unlike the closely related western red cedar(Thuja plicata), northern white cedar is only a small or medium - sized tree, growing to a height of 15 m(49 ft) tall with a 0.9 m(3.0 ft) trunk diameter, exceptionally to 38 metres(125 ft) tall and 1.8 metres(5.9 ft) diameter.[7] The tree is often stunted or prostrate in less favorable locations.The bark is red - brown, furrowed and peels in narrow, longitudinal strips. Northern white cedar has fan - like branches and scaly leaves. The foliage forms in flat sprays with scale-like leaves 3–5 millimetres(1⁄8–3⁄16 in) long.The seed cones are slender, yellow - green, ripening to brown, 9–14 millimetres(3⁄8–9⁄16 in) long and 4–5 millimetres(5⁄32–3⁄16 in) broad,[citation needed] with six to eight overlapping scales. They contain about eight seeds each. The branches may take root if the tree falls. ";
                plant.ImageName = "ThujaSmaragd.jpg";
                plant.Price_Small = 6.3;
                plant.Price_Large = 8.4;
                plant.AvailableDimensions = new List<ProductDimensionInfo>();
                plant.PublishDate = DateTime.Now - TimeSpan.FromDays(4);
                plant.UnitsInStock = 200;
                plant.FreeShipping = false;
                products.Add(plant);
            }

            {
                var plant = new ProductViewModel();
                plant.Name = "Thuja Danica";
                plant.Id = 3;
                plant.Description = "A slow-growing, dense, globular, evergreen shrub that grows to only 20 tall and as wide in the first 20 years. Emerald green foliage is held in vertical sprays. Foliage turns blue-green in winter.";
                plant.ImageName = "Danica.jfif";
                plant.Price_Small = 6.3;
                plant.Price_Large = 8.4;
                plant.AvailableDimensions = new List<ProductDimensionInfo>();
                plant.PublishDate = DateTime.Now - TimeSpan.FromDays(45);
                plant.UnitsInStock = 40;
                plant.FreeShipping = false;
                products.Add(plant);
            }

            {
                var plant = new ProductViewModel();
                plant.Name = "Juniperus chinesis";
                plant.Id = 4;
                plant.Description = "The Chinese juniper(圆柏, 桧) is a species of plant in the cypress family Cupressaceae, native to China, Myanmar, Japan, Korea and the Russian Far East.[1] Growing 1–20 m(3.3–65.6 ft) tall, it is a very variable coniferous evergreen tree or shrub. The leaves grow in two forms, juvenile needle-like leaves 5–10 mm long, and adult scale-leaves 1.5–3 mm long. Mature trees usually continue to bear some juvenile foliage as well as adult, particularly on shaded shoots low in the crown. This species is often dioecious (either male or female plants), but some individual plants produce both sexes of flowers. The blue-black berry-like cones grow to 7–12 mm in diameter, have a whitish waxy bloom, and contain 2–4 seeds; they mature in about 18 months. The male cones, 2–4 mm long, shed their pollen in early spring.The leaves grow in two forms, juvenile needle-like leaves 5–10 mm long, and adult scale-leaves 1.5–3 mm long. Mature trees usually continue to bear some juvenile foliage as well as adult, particularly on shaded shoots low in the crown. This species is often dioecious (either male or female plants), but some individual plants produce both sexes of flowers. The blue-black berry-like cones grow to 7–12 mm in diameter, have a whitish waxy bloom, and contain 2–4 seeds; they mature in about 18 months. The male cones, 2–4 mm long, shed their pollen in early spring.";
                plant.ImageName = "JalowiecChinski.jfif";
                plant.Price_Small = 6.3;
                plant.Price_Large = 8.4;
                plant.AvailableDimensions = new List<ProductDimensionInfo>();
                plant.PublishDate = DateTime.Now - TimeSpan.FromDays(92);
                plant.UnitsInStock = 9;
                plant.FreeShipping = true;
                products.Add(plant);
            }
            
            AllProducts = products;
        }

        public IActionResult Index()
        {
            EnsureProductsLoaded();
            return View(AllProducts);
        }

        public IActionResult Details(int id)
        {
            EnsureProductsLoaded();
            var productResult = AllProducts.Where(p => p.Id == id).FirstOrDefault();
            return View(productResult);
        }
    }
}