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
    /// <param name="explanations">A collection of messages to describe the result of the evaluation.</param>
    public SpecificationEvaluation(
        ISpecification<TCandidate> specification,
        TCandidate? candidate,
        bool isSatisfied,
        params string[] explanations
        )
    {
        Specification = specification;
        Candidate = candidate;
        IsSatisfied = isSatisfied;
        Explanations = explanations;
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
    /// A value that indicates that the specification was satisfied.
    /// </summary>
    public bool IsSatisfied { get; }

    /// <summary>
    /// A value that indicates that the specification was not satisfied.
    /// </summary>
    public bool IsNotSatisfied => !IsSatisfied;

    /// <summary>
    /// A single message to describe the result of the evaluation.
    /// </summary>
    public virtual string Explanation => string.Join("|", Explanations);

    /// <summary>
    /// A collection of messages to describe the result of the evaluation.
    /// </summary>
    public IEnumerable<string> Explanations { get; }
}
