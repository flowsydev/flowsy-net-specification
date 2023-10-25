namespace Flowsy.Specification;

public interface ISpecification<TCandidate>
{
    bool IsSatisfiedBy(TCandidate? candidate);
    
    SpecificationEvaluation<TCandidate> Evaluate(TCandidate? candidate);
    
    ISpecification<TCandidate> And(ISpecification<TCandidate> other);
    ISpecification<TCandidate> Or(ISpecification<TCandidate> other);
    ISpecification<TCandidate> Not();
}