namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(SteelworkingSkill), 3)]   
    [RepairRequiresSkill(typeof(SteelworkingSkill), 3)] 
    public partial class ModernScytheRecipe : Recipe
    {
        public ModernScytheRecipe()
        {
            this.Products = new CraftingElement[] { new CraftingElement<ModernScytheItem>() };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiberglassItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 30, SteelworkingEfficiencySkill.MultiplicativeStrategy) 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernScytheRecipe), Item.Get<ModernScytheItem>().UILink(), 0.5f, typeof(SteelworkingSpeedSkill));    
            this.Initialize(Localizer.DoStr("Modern Scythe"), typeof(ModernScytheRecipe));
            CraftingComponent.AddRecipe(typeof(AssemblyLineObject), this);
        }
    }
    [Serialized]
    [Weight(1000)]
    [Category("Tool")]
    public partial class ModernScytheItem : ScytheItem
    {

        public override LocString DisplayName { get { return Localizer.DoStr("Modern Scythe"); } }
        private static IDynamicValue caloriesBurn = CreateCalorieValue(10, typeof(ScytheEfficiencySkill), typeof(ModernScytheItem), new ModernScytheItem().UILink());
        public override IDynamicValue CaloriesBurn { get { return caloriesBurn; } }

        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(15, SteelworkingSkill.MultiplicativeStrategy, typeof(SteelworkingSkill), Localizer.DoStr("repair cost"));        
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }


        public override float DurabilityRate { get { return DurabilityMax / 2000f; } }
        
        public override Item RepairItem         {get{ return Item.Get<SteelItem>(); } }
        public override int FullRepairAmount    {get{ return 15; } }
    }
}