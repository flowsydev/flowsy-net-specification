namespace Flowsy.Specification;

public sealed class StringMinLengthSpecification : AbstractSpecification<string>
{
    public StringMinLengthSpecification(
        int minLength,
        string? satisfactionMessage = null,
        Func<string?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<string?, string>? resolveFailureMessage = null
    ) : base(satisfactionMessage, resolveSatisfactionMessage, failureMessage, resolveFailureMessage)
    {
        MinLength = minLength;
    }
    
    public int MinLength { get; }

    public override bool IsSatisfiedBy(string? candidate)
        => candidate is null || candidate.Length > 0;

    public override SpecificationEvaluation<string> Evaluate(string? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        
        var explanation = isSatisfied 
            ? GetSatisfactionMessage(candidate) ?? string.Format(Resources.Strings.ValueIsAtLeastNCharactersLong, MinLength)
            : GetFailureMessage(candidate) ?? string.Format(Resources.Strings.ValueMustBeAtLeastNCharactersLong, MinLength);
        
        return new SpecificationEvaluation<string>(this, candidate, isSatisfied, explanation);
    }
}