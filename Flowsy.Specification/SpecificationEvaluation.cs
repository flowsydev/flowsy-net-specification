namespace Flowsy.Specification;

/// <summary>
/// Represents the results of evaluating a given specification.
/// </summary>
/// <typeparam name="TCandidate">The type of candidate for the specification.</typeparam>
public class SpecificationEvaluation<TCandidate> : ISpecificationEvaluation
{
    /// <summary>
    /// Creates a new instance of a specification evaluation.
    /// </summary>
    /// <param name="specification">The evaluated specification.</param>
    /// <param name="candidate">The candidate for the specification.</param>
    /// <param name="isSatisfied">A value that indicates the satisfaction or failure of the evaluation.</param>
    /// <param name="explanation">A message to describe the result of the evaluation.</param>
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

    /// <summary>
    /// The evaluated specification.
    /// </summary>
    public ISpecification<TCandidate> Specification { get; }
    
    /// <summary>
    /// The candidate for the specification.
    /// </summary>
    public TCandidate? Candidate { get; }
    
    /// <summary>
    /// A value that indicates the satisfaction or failure of the evaluation.
    /// </summary>
    public bool IsSatisfied { get; }
    
    /// <summary>
    /// A message to describe the result of the evaluation.
    /// </summary>
    public string Explanation { get; }
}
