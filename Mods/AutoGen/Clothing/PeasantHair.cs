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
    [Category("Hidden")]  
    [Weight(100)]      
    public partial class PeasantHairItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Peasant Hair"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("The haircut your mom always made you get before you realized you could make your own decisions."); } }
        public override string Slot             { get { return ClothingSlot.Hair; } }             
        public override bool Starter            { get { return true ; } }                       

    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 0)]
    public class PeasantHairRecipe : Recipe
    {
        public PeasantHairRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PeasantHairItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FurPeltItem>(typeof(ClothesmakingEfficiencySkill), 5, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(10);
            this.Initialize(Localizer.DoStr("Peasant Hair"), typeof(PeasantHairRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}