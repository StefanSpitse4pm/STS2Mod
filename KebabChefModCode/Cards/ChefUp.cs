using KebabChefMod.KebabChefModCode.Cards;
using KebabChefMod.KebabChefModCode.Powers;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;

namespace KebabChefMod.KebabChefModCode.Cards;

public class ChefUp() : KebabChefModCard(1,
    CardType.Skill, CardRarity.Basic,
    TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<SkewerPower>(3M)];

    protected override async Task OnPlay(
        PlayerChoiceContext choiceContext,
        CardPlay play)
    {
        ChefUp chefUp = this;
        SkewerPower skewerPower = await PowerCmd.Apply<SkewerPower>(choiceContext, chefUp.Owner.Creature, chefUp.DynamicVars["SkewerPower"].BaseValue, chefUp.Owner.Creature, (CardModel)null);
    }

    protected override void OnUpgrade() => EnergyCost.UpgradeBy(-1);
}