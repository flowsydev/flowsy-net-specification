namespace Flowsy.Specification;

public class AndSpecification<TCandidate> : AbstractSpecification<TCandidate>
{
    private readonly ISpecification<TCandidate> _left;
    private readonly ISpecification<TCandidate> _right;

    public AndSpecification(
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
        => _left.IsSatisfiedBy(candidate) && _right.IsSatisfiedBy(candidate);

    public override SpecificationEvaluation<TCandidate> Evaluate(TCandidate? candidate)
    {
        var leftEvaluation = _left.Evaluate(candidate);
        var rightEvaluation = _right.Evaluate(candidate);
        
        var isSatisfied = leftEvaluation.IsSatisfied && rightEvaluation.IsSatisfied;
        var explanation = $"{leftEvaluation.Explanation} | {rightEvaluation.Explanation}";
        
        return new SpecificationEvaluation<TCandidate>(this, candidate, isSatisfied, explanation);
    }
}