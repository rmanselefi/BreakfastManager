using ErrorOr;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BuberBreakfast.ServiceErrors;

public static class Errors{
    public static class Breakfast{
        public static Error NotFound =>Error.NotFound("BreakFast not found", "");
    }
}