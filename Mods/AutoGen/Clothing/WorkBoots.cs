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
    public partial class WorkBootsItem :
        ClothingItem        
    {

        public override LocString DisplayName         { get { return Localizer.DoStr("Work Boots"); } }
        public override LocString DisplayDescription  { get { return Localizer.DoStr("CALORIE SHOES???"); } }
        public override string Slot             { get { return ClothingSlot.Shoes; } }             
        public override bool Starter            { get { return false ; } }                       

        private static Dictionary<UserStatType, float> flatStats = new Dictionary<UserStatType, float>()
    {
                { UserStatType.CalorieRate, -0.1f }
    };
public override Dictionary<UserStatType, float> GetFlatStats() { return flatStats; }
    }

    
    [RequiresSkill(typeof(ClothesmakingSkill), 3)]
    public class WorkBootsRecipe : Recipe
    {
        public WorkBootsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WorkBootsItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CelluloseFiberItem>(typeof(ClothesmakingEfficiencySkill), 20, ClothesmakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LeatherHideItem>(typeof(ClothesmakingEfficiencySkill), 30, ClothesmakingEfficiencySkill.MultiplicativeStrategy)
            };
            this.CraftMinutes = new ConstantValue(1);
            this.Initialize(Localizer.DoStr("Work Boots"), typeof(WorkBootsRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    } 
}