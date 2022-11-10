using Fluxor;
using Introspection.Front.Domain.Models;
using Introspection.Front.Domain.Store;
using Introspection.Front.Domain.Store.Actions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Introspection.Front.Blazor.Pages;

public class DayBase : ComponentBase, IDisposable
{
    [Inject] protected IState<AppState> State { get; set; } = null!;
    [Inject] private IDispatcher Dispatcher { get; set; } = null!;
    protected readonly MudTheme Theme = new();

    /// <summary>
    /// On Initialized we load dayWills
    /// </summary>
    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(new LoadDayWills());
        State.StateChanged += StateOnStateChanged;
    }

    /// <summary>
    /// On validating dayWill
    /// </summary>
    /// <param name="dayWill"></param>
    protected void ValidateDayWill(DayWill dayWill)
    {
        var status = dayWill.Status is DayValidationStatus.Validated
            ? DayValidationStatus.Missed
            : DayValidationStatus.Validated;
        
        Dispatcher.Dispatch(new ValidateDayWill(dayWill, status));
    }
    
    protected static Severity GetSeverity(DayValidationStatus status) 
        => status == DayValidationStatus.Missed ? Severity.Error : Severity.Success;

    private void StateOnStateChanged(object? sender, EventArgs e) 
        => StateHasChanged();

    public void Dispose() 
        => State.StateChanged -= StateOnStateChanged;
}