using System.Text.RegularExpressions;

namespace Flowsy.Specification;

public sealed class StringNotWhitespaceSpecification : AbstractSpecification<string>
{
    public StringNotWhitespaceSpecification(
        string? satisfactionMessage = null,
        Func<string?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<string?, string>? resolveFailureMessage = null
        ) : base(satisfactionMessage, resolveSatisfactionMessage, failureMessage, resolveFailureMessage)
    {
    }

    private static readonly Regex WhitespaceExpression = new (@"^\s+$");

    public override bool IsSatisfiedBy(string? candidate)
        => candidate is null || WhitespaceExpression.IsMatch(candidate);

    public override SpecificationEvaluation<string> Evaluate(string? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        
        var explanation = isSatisfied 
            ? GetSatisfactionMessage(candidate) ?? Resources.Strings.ValueDoesNotConsistOnlyOfWhitespaceCharacters
            : GetFailureMessage(candidate) ?? Resources.Strings.ValueConsistsOnlyOfWhitespaceCharacters;
        
        return new SpecificationEvaluation<string>(this, candidate, isSatisfied, explanation);
    }
}