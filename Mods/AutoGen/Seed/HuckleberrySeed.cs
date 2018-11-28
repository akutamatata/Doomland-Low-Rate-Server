namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
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
    public partial class HuckleberrySeedItem : SeedItem
    {
        static HuckleberrySeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override LocString DisplayName        { get { return Localizer.DoStr("Huckleberry Seed"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a huckleberry bush."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Huckleberry"); } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class HuckleberrySeedPackItem : SeedPackItem
    {
        static HuckleberrySeedPackItem() { }

        public override LocString DisplayName        { get { return Localizer.DoStr("Huckleberry Seed Pack"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow a huckleberry bush."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Huckleberry"); } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 2)]    
    public class HuckleberrySeedRecipe : Recipe
    {
        public HuckleberrySeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HuckleberrySeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberriesItem>(typeof(SeedProductionEfficiencySkill), 4, SeedProductionEfficiencySkill.MultiplicativeStrategy)   
            };
            SkillModifiedValue value = new SkillModifiedValue(1, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(HuckleberrySeedRecipe), Item.Get<HuckleberrySeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<HuckleberrySeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize(Localizer.DoStr("Huckleberry Seed"), typeof(HuckleberrySeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}