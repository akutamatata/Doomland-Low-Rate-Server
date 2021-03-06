namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Gameplay.Objects;

    [Serialized]
    [Weight(100)]                                          
    public partial class CamasMashItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Camas Mash"); } }
        public override LocString DisplayNamePlural             { get { return Localizer.DoStr("Camas Mash"); } } 
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A mushy camas paste with some fat added for flavor and texture."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 1, Fat = 9, Protein = 2, Vitamins = 1};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    public partial class CamasMashRecipe : Recipe
    {
        public CamasMashRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CamasMashItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CamasBulbItem>(typeof(CampfireCreationsEfficiencySkill), 2, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(CampfireCreationsEfficiencySkill), 1, CampfireCreationsEfficiencySkill.MultiplicativeStrategy),    
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CamasMashRecipe), Item.Get<CamasMashItem>().UILink(), 1, typeof(CampfireCreationsSpeedSkill));     
            this.Initialize(Localizer.DoStr("Camas Mash"), typeof(CamasMashRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}