namespace Gestao.Test.Utils;

internal static class AssertExtensions
{
    public static void WithMessage(this Exception ex, string message, bool ignoreCaseSensitive = false)
    {
        var exceptionMessage = ex.Message;

        if (ignoreCaseSensitive)
        {
            exceptionMessage = exceptionMessage.ToLowerInvariant();
            message = message.ToLowerInvariant();
        }

        Assert.Equal(message, exceptionMessage);
    }
}
