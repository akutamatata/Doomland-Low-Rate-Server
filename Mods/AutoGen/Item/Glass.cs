namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(GlassworkingSkill), 1)]   
    public partial class GlassRecipe : Recipe
    {
        public GlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(GlassProductionEfficiencySkill), 4, GlassProductionEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GlassRecipe), Item.Get<GlassItem>().UILink(), 1, typeof(GlassProductionSpeedSkill));    
            this.Initialize(Localizer.DoStr("Glass"), typeof(GlassRecipe));

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]
    [Solid, Wall, Constructed,BuildRoomMaterialOption]
    [Tier(2)]                                          
    [RequiresSkill(typeof(GlassProductionEfficiencySkill), 1)]   
    public partial class GlassBlock :
        Block            
        , IRepresentsItem     
    {
        public Type RepresentedItemType { get { return typeof(GlassItem); } }    
    }

    [Serialized]
    [MaxStackSize(20)]                           
    [Weight(10000)]      
    [Currency]                                              
    [ItemTier(2)]                                      
    public partial class GlassItem :
    BlockItem<GlassBlock>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Glass"); } } 
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Glass"); } } 
        public override LocString DisplayDescription { get { return Localizer.DoStr("A transparent, solid material useful for more than just windows."); } }


        private static Type[] blockTypes = new Type[] {
            typeof(GlassStacked1Block),
            typeof(GlassStacked2Block),
            typeof(GlassStacked3Block),
            typeof(GlassStacked4Block)
        };
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Serialized, Solid] public class GlassStacked1Block : PickupableBlock { }
    [Serialized, Solid] public class GlassStacked2Block : PickupableBlock { }
    [Serialized, Solid] public class GlassStacked3Block : PickupableBlock { }
    [Serialized, Solid,Wall] public class GlassStacked4Block : PickupableBlock { } //Only a wall if it's all 4 Glass
}