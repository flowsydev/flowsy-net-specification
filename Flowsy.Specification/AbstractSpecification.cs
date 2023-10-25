namespace Flowsy.Specification;

public abstract class AbstractSpecification<TCandidate> : ISpecification<TCandidate>
{
    protected AbstractSpecification(
        string? satisfactionMessage = null,
        Func<TCandidate?, string>? resolveSatisfactionMessage = null,
        string? failureMessage = null,
        Func<TCandidate?, string>? resolveFailureMessage = null
        )
    {
        SatisfactionMessage = satisfactionMessage;
        ResolveSatisfactionMessage = resolveSatisfactionMessage;
        FailureMessage = failureMessage;
        ResolveFailureMessage = resolveFailureMessage;
    }
    
    protected string? SatisfactionMessage { get; }
    protected Func<TCandidate?, string>? ResolveSatisfactionMessage { get; }
    protected string? FailureMessage { get; }
    protected Func<TCandidate?, string>? ResolveFailureMessage { get; }
    
    protected virtual string? GetSatisfactionMessage(TCandidate? candidate)
        => SatisfactionMessage ?? ResolveSatisfactionMessage?.Invoke(candidate);

    protected virtual string? GetFailureMessage(TCandidate? candidate)
        => FailureMessage ?? ResolveFailureMessage?.Invoke(candidate);
    
    public abstract bool IsSatisfiedBy(TCandidate? candidate);
    public abstract SpecificationEvaluation<TCandidate> Evaluate(TCandidate? candidate);
    
    public virtual ISpecification<TCandidate> And(ISpecification<TCandidate> other)
        => new AndSpecification<TCandidate>(this, other);

    public virtual ISpecification<TCandidate> Or(ISpecification<TCandidate> other)
        => new OrSpecification<TCandidate>(this, other);

    public virtual ISpecification<TCandidate> Not()
        => new NotSpecification<TCandidate>(this);
}