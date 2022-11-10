using Fluxor;
using Introspection.Front.Domain.Store;

namespace Introspection.Front.Blazor.Store;

public class IntrospectionFeature : Feature<AppState>
{
    public override string GetName()
        => "IntrospectionApp";

    protected override AppState GetInitialState()
        => AppState.Empty;
}