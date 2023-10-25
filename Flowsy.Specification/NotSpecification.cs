namespace Flowsy.Specification;

public class NotSpecification<TCandidate> : AbstractSpecification<TCandidate>
{
    private readonly ISpecification<TCandidate> _target;

    public NotSpecification(
        ISpecification<TCandidate> target,
        string? satisfactionMessage = null,
        Func<TCandidate?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<TCandidate?, string>? resolveFailureMessage = null
    ) : base(satisfactionMessage, resolveSatisfactionMessage, failureMessage, resolveFailureMessage)
    {
        _target = target;
    }

    public override bool IsSatisfiedBy(TCandidate? candidate)
        => !_target.IsSatisfiedBy(candidate);
    
    public override SpecificationEvaluation<TCandidate> Evaluate(TCandidate? candidate)
    {
        var isSatisfied = IsSatisfiedBy(candidate);
        
        var explanation = isSatisfied
            ? GetSatisfactionMessage(candidate) ?? Resources.Strings.TheTargetSpecificationWasNotSatisfied
            : GetFailureMessage(candidate) ?? Resources.Strings.TheTargetSpecificationWasSatisfied;

        return new SpecificationEvaluation<TCandidate>(this, candidate, isSatisfied, explanation);
    }
}