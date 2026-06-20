using KebabChefMod.KebabChefModCode.Powers;
using KebabChefMod.KebabChefModCode.Relics;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace KebabChefMod.KebabChefModCode.Relics;

public class Grill() : KebabChefModRelic
{
    public override RelicRarity Rarity =>
        RelicRarity.Starter;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<SkewerPower>(1M)];

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        Grill grill = this;
        grill.Flash();
        SkewerPower skewerPower = await PowerCmd.Apply<SkewerPower>(choiceContext, grill.Owner.Creature, grill.DynamicVars["SkewerPower"].BaseValue, grill.Owner.Creature, (CardModel)null);
    }
}