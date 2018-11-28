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
    public partial class BasicBackpackItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Basic Backpack"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr(""); } }
        public override string Slot             { get { return ClothingSlot.Back; } }             
        public override bool Starter            { get { return false ; } }                       

        private static Dictionary<UserStatType, float> flatStats = new Dictionary<UserStatType, float>()
    {
                { UserStatType.MaxCarryWeight, 5000f }
    };
public override Dictionary<UserStatType, float> GetFlatStats() { return flatStats; }
    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 1)]
    public class BasicBackpackRecipe : Recipe
    {
        public BasicBackpackRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BasicBackpackItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 4, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(ClothesmakingEfficiencySkill), 5, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Basic Backpack"), typeof(BasicBackpackRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}