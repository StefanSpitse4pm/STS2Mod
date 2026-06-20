using KebabChefMod.KebabChefModCode.Powers;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace KebabChefMod.KebabChefModCode.Powers;

public class SkewerPower() : KebabChefModPower
{
    
    private const string _skewerStackKey = "SkewerStack";
    
    
    public override PowerType Type =>
        PowerType.Buff;

    public override PowerStackType StackType =>
        PowerStackType.Counter;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(3, ValueProp.Unpowered), new IntVar("SkewerStack", 10)];

    public void SetDamage(Decimal damage)
    {
        AssertMutable();
        DynamicVars.Damage.BaseValue = damage;
    }

    public override async Task AfterPowerAmountChanged(PlayerChoiceContext choiceContext, PowerModel power, decimal amount, Creature? applier,
        CardModel? cardSource)
    {
        SkewerPower skewerPower = this;
        
        if (skewerPower.Amount >= skewerPower.DynamicVars["SkewerStack"].IntValue)
        {
            ICombatState combatState = Owner.CombatState;
            if (combatState == null) return;
            IEnumerable<DamageResult> damageResult =
                await CreatureCmd.Damage(choiceContext,combatState.HittableEnemies, skewerPower.DynamicVars.Damage, skewerPower.Owner);
            skewerPower.SetAmount(0);
        }
    }

}