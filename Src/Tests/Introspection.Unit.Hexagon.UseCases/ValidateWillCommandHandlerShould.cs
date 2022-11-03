using Introspection.Back.Domain.Models;
using Introspection.Domain.UseCases;

namespace Introspection.Unit.Domain.UseCases;

public class ValidateWillCommandHandlerShould
{

    [Fact]
    public async Task Mark_as_validated_one_will_for_a_specific_day()
    {
        var will = new Will("SleepEarly");
        var date = new DateTime(2022, 01, 01);

        await new ValidateWillCommandHandler()
            .Handle(will, date);
        
        Assert.Equal(DayValidationStatus.Validated, will.DayValidation(date));
    }
}