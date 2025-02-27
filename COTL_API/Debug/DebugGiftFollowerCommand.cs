using System.Collections;

namespace COTL_API.Debug;

public class DebugGiftFollowerCommand : CustomFollowerCommand.CustomFollowerCommand
{
    public override string InternalName => "DEBUG_GIFT_FOLLOWER_COMMAND";
    public override bool ShouldAppearFor(Follower follower) => false;

    public override void Execute(interaction_FollowerInteraction interaction,
        FollowerCommands finalCommand)
    {
        interaction.StartCoroutine(interaction.FrameDelayCallback(delegate
        {
            interaction.eventListener.PlayFollowerVO(interaction.positiveAcknowledgeVO);
            interaction.follower.Brain.HardSwapToTask(new FollowerTask_InstantPoop());
            Inventory.ChangeItemQuantity(Plugin.DebugItem, -1);
        }));
        interaction.Close();
    }
}