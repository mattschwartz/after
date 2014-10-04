using After.Interactable.Conditions;

public class GeneratorConditions : RequiredItemConditions
{
    private bool Fueled = false;

    public override bool ConditionsMet()
    {
        bool result = true;

        if (!Fueled) {
            result = false;
        } 
        
        // Consume fuel if player has it
        // But make player have to turn it on again
        if (PlayerHasItem()) {
            Fueled = true;
        }

        return result;
    }
}

