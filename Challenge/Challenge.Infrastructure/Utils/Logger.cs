using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Challenges.Infrastructure.Utils;

public static class Logger
{
    public static void Debug<T>(this ILogger<T> logger, EventId eventId, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Debug, eventId, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Debug<T>(this ILogger<T> logger, EventId eventId, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Debug, eventId, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Debug<T>(this ILogger<T> logger, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Debug, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Debug<T>(this ILogger<T> logger, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 1)
    {
        logger.Log(LogLevel.Debug, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Trace<T>(this ILogger<T> logger, EventId eventId, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Trace, eventId, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Trace<T>(this ILogger<T> logger, EventId eventId, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Trace, eventId, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Trace<T>(this ILogger<T> logger, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Trace, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Trace<T>(this ILogger<T> logger, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Trace, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Information<T>(this ILogger<T> logger, EventId eventId, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Information, eventId, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Information<T>(this ILogger<T> logger, EventId eventId, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Information, eventId, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Information<T>(this ILogger<T> logger, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Information, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Information<T>(this ILogger<T> logger, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Information, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Warning<T>(this ILogger<T> logger, EventId eventId, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Warning, eventId, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Warning<T>(this ILogger<T> logger, EventId eventId, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Warning, eventId, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Warning<T>(this ILogger<T> logger, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Warning, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Warning<T>(this ILogger<T> logger, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Warning, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Error<T>(this ILogger<T> logger, EventId eventId, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Error, eventId, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Error<T>(this ILogger<T> logger, EventId eventId, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Error, eventId, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Error<T>(this ILogger<T> logger, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Error, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Error<T>(this ILogger<T> logger, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Error, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Critical<T>(this ILogger<T> logger, EventId eventId, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Critical, eventId, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Critical<T>(this ILogger<T> logger, EventId eventId, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Critical, eventId, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Critical<T>(this ILogger<T> logger, Exception exception, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Critical, exception, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? exception.Message}); line: {sourceLineNumber}", @params?.GetArguments());
    }

    public static void Critical<T>(this ILogger<T> logger, FormattableString @params = null, [CallerMemberName] string memberName = null, [CallerLineNumber] int sourceLineNumber = 0)
    {
        logger.Log(LogLevel.Critical, $"{typeof(T).Name}.{memberName ?? string.Empty}({@params?.ToString() ?? string.Empty}); line: {sourceLineNumber}", @params?.GetArguments());
    }
}