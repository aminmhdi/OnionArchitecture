namespace Domain.Exceptions
{
    [Serializable]
    internal class InvalidParameterException : Exception
    {
        public InvalidParameterException(string? parameterName) : base($"Invalid parameter value: {parameterName}")
        {
        }
    }
}
