namespace Flowsy.Specification;

public class SpecificationEvaluation<TCandidate> 
{
    public SpecificationEvaluation(
        ISpecification<TCandidate> specification,
        TCandidate? candidate,
        bool isSatisfied,
        string explanation
        )
    {
        Specification = specification;
        Candidate = candidate;
        IsSatisfied = isSatisfied;
        Explanation = explanation;
    }

    public ISpecification<TCandidate> Specification { get; }
    public TCandidate? Candidate { get; }
    public bool IsSatisfied { get; }
    public string Explanation { get; }
}
