namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
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
    [Weight(0)]
    [Category("Hidden")]
    public partial class RoundedFaceItem :
        ClothingItem
    {
        public override LocString DisplayName        { get { return Localizer.DoStr("Rounded Face"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Face"); } }
        public override string Slot                  { get { return ClothingSlot.Face; } } 
    }
}