using Fluxor;

namespace Introspection.Adapters.Primary.Store;

public class IntrospectionFeature : Feature<AppState>
{
    public override string GetName()
        => "IntrospectionApp";

    protected override AppState GetInitialState()
        => AppState.Empty;
}