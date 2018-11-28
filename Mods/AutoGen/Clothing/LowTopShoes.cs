namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(100)]      
    public partial class LowTopShoesItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Low Top Shoes"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Basic, ordinary, every day, run of the mill, nondescript, conventional, commonplace, humdrum, standard, middle-of-the-road, garden-variety low-top shoes."); } }
        public override string Slot             { get { return ClothingSlot.Shoes; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class LowTopShoesRecipe : Recipe
    {
        public LowTopShoesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LowTopShoesItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 4, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Low Top Shoes"), typeof(LowTopShoesRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}