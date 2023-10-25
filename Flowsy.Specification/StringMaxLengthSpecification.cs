namespace Flowsy.Specification;

public sealed class StringMaxLengthSpecification : AbstractSpecification<string>
{
    public StringMaxLengthSpecification(
        int maxLength,
        string? satisfactionMessage = null,
        Func<string?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<string?, string>? resolveFailureMessage = null
    ) : base(satisfactionMessage, resolveSatisfactionMessage, failureMessage, resolveFailureMessage)
    {
        MaxLength = maxLength;
    }
    
    public int MaxLength { get; }

    public override bool IsSatisfiedBy(string? candidate)
        => candidate is null || candidate.Length > 0;

    public override SpecificationEvaluation<string> Evaluate(string? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        
        var explanation = isSatisfied 
            ? GetSatisfactionMessage(candidate) ?? string.Format(Resources.Strings.ValueDoesNotExceedNCharacters, MaxLength)
            : GetFailureMessage(candidate) ?? string.Format(Resources.Strings.ValueMustNotExceedNCharacters, MaxLength);
        
        return new SpecificationEvaluation<string>(this, candidate, isSatisfied, explanation);
    }
}