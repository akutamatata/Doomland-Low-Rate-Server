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
    [Yield(typeof(BeansItem), typeof(ForestForagerSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [Crop]  
    [Weight(50)]  
    public partial class BeansItem : SeedItem
    {
        static BeansItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 1, Fat = 3, Protein = 4, Vitamins = 0 };

        public override LocString DisplayName        { get { return Localizer.DoStr("Beans"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A good source of protein."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Beans"); } }

        public override float Calories { get { return 120; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(50)]  
    public partial class BeansPackItem : SeedPackItem
    {
        static BeansPackItem() { }

        public override LocString DisplayName        { get { return Localizer.DoStr("Beans Pack"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A good source of protein."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Beans"); } }
    }

}