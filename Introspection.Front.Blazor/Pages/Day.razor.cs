using Fluxor;
using Introspection.Front.Blazor.Store;
using Introspection.Front.Blazor.Store.Actions;
using Microsoft.AspNetCore.Components;

namespace Introspection.Front.Blazor.Pages;

public class DayBase : ComponentBase, IDisposable
{
    [Inject] protected IState<AppState> State { get; set; }
    [Inject] private IDispatcher Dispatcher { get; set; }

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new LoadDayWills(new DateTime(2022, 01, 01)));
        State.StateChanged += StateOnStateChanged;
    }

    private void StateOnStateChanged(object? sender, EventArgs e) 
        => StateHasChanged();

    public void Dispose() 
        => State.StateChanged -= StateOnStateChanged;
}