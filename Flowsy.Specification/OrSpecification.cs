namespace Flowsy.Specification;

public class OrSpecification<TCandidate> : AbstractSpecification<TCandidate>
{
    private readonly ISpecification<TCandidate> _left;
    private readonly ISpecification<TCandidate> _right;

    public OrSpecification(
        ISpecification<TCandidate> left,
        ISpecification<TCandidate> right,
        string? satisfactionMessage = null,
        Func<TCandidate?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<TCandidate?, string>? resolveFailureMessage = null
    ) : base(satisfactionMessage, resolveSatisfactionMessage, failureMessage, resolveFailureMessage)
    {
        _left = left;
        _right = right;
    }

    public override bool IsSatisfiedBy(TCandidate? candidate)
        => _left.IsSatisfiedBy(candidate) || _right.IsSatisfiedBy(candidate);

    public override SpecificationEvaluation<TCandidate> Evaluate(TCandidate? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        
        var explanation = isSatisfied
            ? GetSatisfactionMessage(candidate) ?? Resources.Strings.AtLeastOneOfTheSpecificationsWasSatisfied
            : GetFailureMessage(candidate) ?? Resources.Strings.NoneOfTheSpecificationsWasSatisfied;

        return new SpecificationEvaluation<TCandidate>(this, candidate, isSatisfied, explanation);
    }
}