namespace Flowsy.Specification;

public sealed class StringNotEmptySpecification : AbstractSpecification<string>
{
    public StringNotEmptySpecification(
        string? satisfactionMessage = null,
        Func<string?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<string?, string>? resolveFailureMessage = null
        ) : base(satisfactionMessage, resolveSatisfactionMessage, failureMessage, resolveFailureMessage)
    {
    }

    public override bool IsSatisfiedBy(string? candidate)
        => candidate is null || candidate.Length > 0;

    public override SpecificationEvaluation<string> Evaluate(string? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        
        var explanation = isSatisfied 
            ? GetSatisfactionMessage(candidate) ?? string.Format(Resources.Strings.XIsNotAnEmptyValue, candidate)
            : GetFailureMessage(candidate) ?? Resources.Strings.TheValueIsEmpty;
        
        return new SpecificationEvaluation<string>(this, candidate, isSatisfied, explanation);
    }
}