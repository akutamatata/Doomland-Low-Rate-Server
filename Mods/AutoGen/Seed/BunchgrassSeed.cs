namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [Weight(50)]  
    public partial class BunchgrassSeedItem : SeedItem
    {
        static BunchgrassSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Bunchgrass Seed"; } }
        public override string Description  { get { return "Plant to grow bunchgrass."; } }
        public override string SpeciesName  { get { return "Bunchgrass"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class BunchgrassSeedPackItem : SeedPackItem
    {
        static BunchgrassSeedPackItem() { }

        public override string FriendlyName { get { return "Bunchgrass Seed Pack"; } }
        public override string Description  { get { return "Plant to grow bunchgrass."; } }
        public override string SpeciesName  { get { return "Bunchgrass"; } }
    }
	
	[RequiresSkill(typeof(SeedProductionSkill), 4)]    
    public class BunchgrassSeedRecipe : Recipe
    {
        public BunchgrassSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BunchgrassSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlantFibersItem>(typeof(SeedProductionEfficiencySkill), 150, SeedProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(BunchgrassSeedRecipe), Item.Get<BunchgrassSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<BunchgrassSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Bunchgrass Seed", typeof(BunchgrassSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }

}