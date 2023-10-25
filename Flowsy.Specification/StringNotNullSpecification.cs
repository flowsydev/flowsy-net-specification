namespace Flowsy.Specification;

public sealed class StringNotNullSpecification : AbstractSpecification<string>
{
    public StringNotNullSpecification(
        string? satisfactionMessage = null,
        Func<string?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<string?, string>? resolveFailureMessage = null
        ) : base(satisfactionMessage, resolveSatisfactionMessage, failureMessage, resolveFailureMessage)
    {
    }

    public override bool IsSatisfiedBy(string? candidate) 
        => candidate is not null;

    public override SpecificationEvaluation<string> Evaluate(string? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        
        var explanation = isSatisfied 
            ? GetSatisfactionMessage(candidate) ?? string.Format(Resources.Strings.XIsNotANullValue, candidate)
            : GetFailureMessage(candidate) ?? Resources.Strings.TheValueIsNull;
        
        return new SpecificationEvaluation<string>(this, candidate, isSatisfied, explanation);
    }
}