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
    [Weight(10)]                                          
    [Yield(typeof(FireweedShootsItem), typeof(TundraTravellerSkill), new float[] {1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f})][Tag("Crop")]      
    [Crop]                                                      
    public partial class FireweedShootsItem :
        FoodItem            
    {
        public override LocString DisplayName                   { get { return Localizer.DoStr("Fireweed Shoots"); } }
        public override LocString DisplayDescription            { get { return Localizer.DoStr("A bitter, brightly colored shoot similar to asparagus."); } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 0, Protein = 0, Vitamins = 4};
        public override float Calories                          { get { return 150; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}